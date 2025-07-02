using D2_Modul3.Data;
using D2_Modul3.Entities;
using D2_Modul3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
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
        [FromQuery] string? sort = "desc",
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

            if (sort.ToLower() == "asc")
            {
                query = query.OrderBy(c => c.id);
            } else
            {
                query = query.OrderByDescending(c => c.id);
            }

            if (page < 0)
            {
                return UnprocessableEntity(new
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
                return UnprocessableEntity(new
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
                return UnprocessableEntity(new
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

        [HttpPost]
        [Authorize(Roles = "admin")]
        [Route("/courses")]
        public IActionResult AddNewCourse([FromBody] CreateCourseDto createCourseDto)
        {
            var user = User.Identity?.Name;
            if (user is null)
            {
                return Unauthorized(new
                {
                    message = "Access denied. Admin role required."
                });
            }

            if (string.IsNullOrWhiteSpace(createCourseDto.title) || string.IsNullOrWhiteSpace(createCourseDto.description))
            {
                return UnprocessableEntity(new
                {
                    message = "Validation error: please fill all fields."
                });
            }

            if (createCourseDto.modules.Count < 3)
            {
                return UnprocessableEntity(new
                {
                    message = "Validation error: modules at least 3 data."
                });
            }

            if (createCourseDto.price.GetType() == typeof(int))
            {
                return UnprocessableEntity(new
                {
                    message = "Validation error: price must be integer."
                });
            }

            if (createCourseDto.duration.GetType() == typeof(int))
            {
                return UnprocessableEntity(new
                {
                    message = "Validation error: duration must be integer."
                });
            }

            if (createCourseDto.price <= 0 || createCourseDto.duration <= 0)
            {
                return UnprocessableEntity(new
                {
                    message = "Validation error: price or duration must be higher than 0."
                });
            }

            var newCourse = new Courses
            {
                title = createCourseDto.title,
                description = createCourseDto.description,
                price = createCourseDto.price,
                duration = createCourseDto.duration,
                created_at = DateTime.Now,
                updated_at = DateTime.Now
            };

            dbContext.Courses.Add(newCourse);
            dbContext.SaveChanges();

            foreach (var module in createCourseDto.modules)
            {
                var newModule = new Modules
                {
                    course_id = newCourse.id,
                    title = module
                };
                dbContext.Modules.Add(newModule);
            }

            dbContext.SaveChanges();

            return Ok(new
            {
                message = "Course created successfully",
                data = new
                {
                    courseId = newCourse.id,
                    title = newCourse.title,
                    description = newCourse.description,
                    price = newCourse.price,
                    duration = newCourse.duration + " minutes",
                    modules = createCourseDto.modules
                }
            });

        }

        [HttpPut]
        [Authorize(Roles = "admin")]
        [Route("/courses/{courseId:int}")]
        public IActionResult UpdateCourse(int courseId, [FromBody] UpdateCourseDto updateCourseDto)
        {
            var user = User.Identity?.Name;
            if (user is null)
            {
                return Unauthorized(new
                {
                    message = "Access denied. Admin role required."
                });
            }

            if (string.IsNullOrWhiteSpace(updateCourseDto.title) || string.IsNullOrWhiteSpace(updateCourseDto.description))
            {
                return UnprocessableEntity(new
                {
                    message = "Validation error: please fill all fields."
                });
            }

            if (updateCourseDto.modules.Count < 3)
            {
                return UnprocessableEntity(new
                {
                    message = "Validation error: modules at least 3 data."
                });
            }

            if (updateCourseDto.price.GetType() == typeof(int))
            {
                return UnprocessableEntity(new
                {
                    message = "Validation error: price must be integer."
                });
            }

            if (updateCourseDto.duration.GetType() == typeof(int))
            {
                return UnprocessableEntity(new
                {
                    message = "Validation error: duration must be integer."
                });
            }

            if (updateCourseDto.price <= 0 || updateCourseDto.duration <= 0)
            {
                return UnprocessableEntity(new
                {
                    message = "Validation error: price or duration must be higher than 0."
                });
            }

            var selectedCourse = dbContext.Courses.FirstOrDefault(c => c.id.Equals(courseId));
            if (selectedCourse is null)
            {
                return NotFound(new
                {
                    message = "Validation error: course not found."
                });
            }

            selectedCourse.title = updateCourseDto.title;
            selectedCourse.description = updateCourseDto.description;
            selectedCourse.price = updateCourseDto.price;
            selectedCourse.duration = updateCourseDto.duration;

            dbContext.SaveChanges();

            foreach (var module in updateCourseDto.modules)
            {
                var newModule = new Modules
                {
                    course_id = selectedCourse.id,
                    title = module
                };
                dbContext.Modules.Add(newModule);
            }

            dbContext.SaveChanges();

            var modules = (from m in dbContext.Modules
                           where m.course_id.Equals(selectedCourse.id)
                           select m.title).ToList();

            return Ok(new
            {
                message = "Course updated successfully",
                data = new
                {
                    courseId = selectedCourse.id,
                    title = selectedCourse.title,
                    description = selectedCourse.description,
                    price = selectedCourse.price,
                    duration = selectedCourse.duration,
                    modules = modules
                }
            });

        }

    }
}
