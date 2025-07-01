using D2_Modul3.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace D2_Modul3.Controllers
{
    [ApiController]
    public class CouponController : ControllerBase
    {
        private ApplicationDbContext dbContext;

        public CouponController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Route("/coupons")]
        public IActionResult GetCoupons(
        [FromQuery] string? couponCode,
        [FromQuery] int page = 1,
        [FromQuery] int size = 10)
        {
            if (page < 1) page = 1;
            if (size < 1) size = 10;

            var query = dbContext.Coupons.AsQueryable();
            if (!string.IsNullOrEmpty(couponCode))
            {
                query = query.Where(q => q.code.Contains(couponCode));
            }

            if (page < 0)
            {
                return BadRequest(new
                {
                    message = "Validation error: 'page' must be a positive integer."
                });
            }

            int totalCoupons = query.Count();
            int totalPages = (int)Math.Ceiling((double)totalCoupons / size);

            var coupons = query
                .Skip((page - 1) * size)
                .Take(size)
                .Select(c => new
                {
                    couponId = c.id,
                    couponCode = c.code,
                    discountValue = c.discount_pct,
                    expiryDate = c.expiry_date,
                    quota = c.quota
                }).ToList();

            return Ok(new
            {
                data = coupons,
                pagination = new
                {
                    page = page,
                    size = size,
                    totalPage = totalPages
                }
            });

        }

    }
}
