using D2_Modul3.Data;
using D2_Modul3.Entities;
using D2_Modul3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace D2_Modul3.Controllers
{
    public class CourseController : ControllerBase
    {
        private ApplicationDbContext dbContext;

        public CourseController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Route("/courses")]
        public IActionResult GetCourses(
        [FromQuery] string? title,
        [FromQuery] int page = 1,
        [FromQuery] int size = 10)
        {
            if (page < 1) page = 1;
            if (size < 1) size = 10;

            var query = dbContext.Courses.AsQueryable();
            if (!string.IsNullOrEmpty(title))
            {
                query = query.Where(c => c.title.Contains(title));
            }

            if (page < 0)
            {
                return BadRequest(new
                {
                    message = "Validation error: 'page' must be a positive integer."
                });
            }

            int totalCourses = query.Count();
            int totalPages = (int)Math.Ceiling((double)totalCourses / size);

            var courses = query
                .Skip((page - 1) * size)
                .Take(size)
                .Select(c => new
                {
                    c.id,
                    c.title,
                    c.description,
                    c.price
                })
                .ToList();

            return Ok(new
            {
                data = courses,
                pagination = new
                {
                    page = page,
                    size = size,
                    totalPage = totalPages
                }
            });
        }

        [HttpGet]
        [Route("/courses/{courseId:int}")]
        public IActionResult GetCourseDetails(int courseId)
        {
            if (courseId.GetType() != typeof(int))
            {
                return BadRequest(new
                {
                    message = "Validation error: courseId must be numeric."
                });
            }

            var selectedCourse = dbContext.Courses.FirstOrDefault(c => c.id.Equals(courseId));
            if (selectedCourse == null)
            {
                return NotFound(new
                {
                    message = "Course not found."
                });
            }

            var selectedModules = (from m in dbContext.Modules
                                   where m.course_id.Equals(courseId)
                                   select m.title).ToList();

            return Ok(new
            {
                data = new
                {
                    id = selectedCourse.id,
                    title = selectedCourse.title,
                    description = selectedCourse.description,
                    price = selectedCourse.price,
                    duration = selectedCourse.duration + " minutes",
                    modules = selectedModules
                }
            });
        }

        [HttpPost]
        [Authorize]
        [Route("/courses/{courseId:int}/purchase")]
        public IActionResult PurchaseCourseWithCoupon(
            int courseId,
            [FromQuery] int userId,
            [FromBody] PurchaseDto purchaseDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    message = "Invalid request body."
                });
            }

            var user = User.Identity?.IsAuthenticated;
            if (user == null)
            {
                return Unauthorized(new
                {
                    message = "Please login/register to purchase the course"
                });
            }

            var selectedCourse = dbContext.Courses.FirstOrDefault(c => c.id.Equals(courseId));
            var selectedCoupon = dbContext.Coupons.FirstOrDefault(c => c.code.Contains(purchaseDto.coupon_code));
            if (selectedCourse is null)
            {
                return NotFound(new
                {
                    message = "Course not found."
                });
            }

            if (selectedCoupon is null)
            {
                return NotFound(new
                {
                    message = "Coupon not found."
                });
            }

            if (DateTime.Now > selectedCoupon.expiry_date || selectedCoupon.quota <= 0)
            {
                return BadRequest(new
                {
                    message = "Validation error: coupon code has expired or quota exceeded."
                });
            }

            var newPrice = (double)(selectedCourse.price - selectedCoupon.discount_pct);
            var newPurchase = new Purchases
            {
                user_id = userId,
                course_id = courseId,
                coupon_id = selectedCoupon.id,
                price_paid = newPrice,
                payment_method = purchaseDto.payment_method,
                purchased_at = DateTime.Now
            };

            selectedCoupon.quota -= 1;
            dbContext.Purchases.Add(newPurchase);
            dbContext.SaveChanges();

            return Ok(new
            {
                message = "Course purchased successfully",
                data = new
                {
                    purchaseId = newPurchase.id,
                    courseId = courseId,
                    userId = userId,
                    purchaseDate = newPurchase.purchased_at,
                    paymentMethod = newPurchase.payment_method,
                    originalPrice = selectedCourse.price,
                    discountApplied = selectedCoupon.discount_pct,
                    paidAmount = newPrice
                }
            });

        }

    }
}
