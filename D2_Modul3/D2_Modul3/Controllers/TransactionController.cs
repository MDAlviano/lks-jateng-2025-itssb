using D2_Modul3.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace D2_Modul3.Controllers
{
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private ApplicationDbContext dbContext;

        public TransactionController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Authorize]
        [Route("/transactions")]
        public IActionResult GetTransaction(
        [FromQuery] string? courseName,
        [FromQuery] string? sortBy,
        [FromQuery] string? userEmail,
        [FromQuery] int page = 1,
        [FromQuery] int size = 10)
        {
            var currentUserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var currentUserRole = User.FindFirstValue(ClaimTypes.Role);

            var query = from p in dbContext.Purchases
                        join c in dbContext.Courses on p.course_id equals c.id
                        join u in dbContext.Users on p.user_id equals u.id
                        join cp in dbContext.Coupons on p.coupon_id equals cp.id into couponJoin
                        from cp in couponJoin.DefaultIfEmpty()
                        select new
                        {
                            transactionId = p.id,
                            userEmail = u.email,
                            courseTitle = c.title,
                            purchaseDate = p.purchased_at,
                            amount = c.price,
                            couponCode = cp != null ? cp.code : "",
                            paidAmount = p.price_paid
                        };

            if (currentUserRole == "student")
            {
                query = query.Where(q => q.userEmail == User.FindFirstValue(ClaimTypes.Email));
                if (!string.IsNullOrWhiteSpace(courseName))
                    query = query.Where(q => q.courseTitle.Contains(courseName));

                if (!string.IsNullOrEmpty(sortBy))
                {
                    if (sortBy.ToLower() == "asc")
                        query = query.OrderBy(q => q.purchaseDate);
                    else if (sortBy.ToLower() == "desc")
                        query = query.OrderByDescending(q => q.purchaseDate);
                    else
                        return UnprocessableEntity(new { message = "Validation error: sortBy must be 'asc' or 'desc'." });
                }
                else
                {
                    query = query.OrderBy(q => q.purchaseDate);
                }
            }
            else if (currentUserRole == "admin")
            {
                if (!string.IsNullOrWhiteSpace(userEmail))
                    query = query.Where(q => q.userEmail.Contains(userEmail));

                if (!string.IsNullOrWhiteSpace(courseName))
                    query = query.Where(q => q.courseTitle.Contains(courseName));

                query = query.OrderByDescending(q => q.purchaseDate);
            }
            else
            {
                return Unauthorized(new { message = "Authorization token missing or invalid." });
            }

            var totalItems = query.Count();
            var totalPages = (int)Math.Ceiling(totalItems / (double)size);
            var pagedData = query.Skip((page - 1) * size).Take(size).ToList();

            return Ok(new
            {
                data = pagedData,
                pagination = new
                {
                    page,
                    size,
                    totalPages
                }
            });
        }


    }
}
