using D2_Modul3.Data;
using D2_Modul3.Entities;
using D2_Modul3.Models;
using Microsoft.AspNetCore.Authorization;
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
        [FromQuery] string? sort = "desc",
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

            if (sort.ToLower() == "asc")
            {
                query = query.OrderBy(c => c.id);
            }
            else
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

        [HttpPost]
        [Authorize(Roles = "admin")]
        [Route("/coupons")]
        public IActionResult CreateCoupon([FromBody] CreateCouponDto createCouponDto)
        {
            var user = User.Identity?.Name;
            if (user is null)
            {
                return Unauthorized(new
                {
                    message = "Authorization token missing or invalid."
                });
            }

            if (string.IsNullOrWhiteSpace(createCouponDto.couponCode))
            {
                return UnprocessableEntity(new
                {
                    message = "Validation error: coupon code must be filled."
                });
            }

            var coupon = dbContext.Coupons.Any(c => c.code.Equals(createCouponDto.couponCode));
            if (coupon)
            {
                return Conflict(new
                {
                    message = "Validation error: coupon already registered."
                });
            }

            if (createCouponDto.expiryDate <= DateTime.Today)
            {
                return UnprocessableEntity(new
                {
                    message = "Validation error: expiry date must be greater than today."
                });
            }

            if (createCouponDto.quota <= 0)
            {
                return UnprocessableEntity(new
                {
                    message = "Validation error: quota must be a positive integer."
                });
            }

            if (createCouponDto.discountValue <= 0)
            {
                return UnprocessableEntity(new
                {
                    message = "Validation error: discount value must be higher than 0."
                });
            }

            var newCoupon = new Coupons
            {
                code = createCouponDto.couponCode,
                discount_pct = createCouponDto.discountValue,
                expiry_date = createCouponDto.expiryDate,
                quota = createCouponDto.quota
            };

            dbContext.Coupons.Add(newCoupon);
            dbContext.SaveChanges();

            return Ok(new
            {
                message = "Coupon created successfully",
                data = new
                {
                    couponId = newCoupon.id,
                    couponCode = newCoupon.code,
                    discountValue = newCoupon.discount_pct,
                    expiryDate = newCoupon.expiry_date,
                    quota = newCoupon.quota
                }
            });
        }

        [HttpPut]
        [Authorize(Roles = "admin")]
        [Route("/coupons/{couponId:int}")]
        public IActionResult UpdateCoupon(int couponId, [FromBody] UpdateCouponDto updateCouponDto)
        {
            var user = User.Identity?.Name;
            if (user is null)
            {
                return Unauthorized(new
                {
                    message = "Access denied. Admin role required."
                });
            }

            if (string.IsNullOrWhiteSpace(updateCouponDto.couponCode))
            {
                return UnprocessableEntity(new
                {
                    message = "Validation error: coupon code must be filled."
                });
            }

            var selectedCoupon = dbContext.Coupons.FirstOrDefault(c => c.id.Equals(couponId));
            if (selectedCoupon is null)
            {
                return NotFound(new
                {
                    message = "Validation error: coupon not found."
                });
            }

            var coupon = dbContext.Coupons.Any(c => c.code.Equals(updateCouponDto.couponCode));
            if (coupon)
            {
                return Conflict(new
                {
                    message = "Validation error: coupon already registered."
                });
            }

            if (updateCouponDto.expiryDate <= DateTime.Today)
            {
                return UnprocessableEntity(new
                {
                    message = "Validation error: expiry date must be greater than today."
                });
            }

            if (updateCouponDto.quota <= 0)
            {
                return UnprocessableEntity(new
                {
                    message = "Validation error: quota must be a positive integer."
                });
            }

            if (updateCouponDto.discountValue <= 0)
            {
                return UnprocessableEntity(new
                {
                    message = "Validation error: discount value must be higher than 0."
                });
            }

            selectedCoupon.code = updateCouponDto.couponCode;
            selectedCoupon.discount_pct = updateCouponDto.discountValue;
            selectedCoupon.expiry_date = updateCouponDto.expiryDate;
            selectedCoupon.quota = updateCouponDto.quota;

            dbContext.SaveChanges();

            return Ok(new
            {
                message = "Coupon created successfully.",
                data = selectedCoupon
            });

        }


    }
}
