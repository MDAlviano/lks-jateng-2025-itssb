using D2_Modul3.Data;
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

        //[HttpPost]
        //[Authorize]
        //[Route("/courses/{courseId:int}/purchase")]
        //public IActionResult PurchaseCourseWithCoupon(int courseId, [FromQuery] int userId, [FromBody] PurchaseDto purchaseDto)
        //{
        //    if(!ModelState.IsValid)
        //    {
        //        return BadRequest(new
        //        {
        //            message = "Invalid request body."
        //        });
        //    }

        //    var user = User.Identity?.IsAuthenticated;

        //    if(user == null)
        //    {
        //        return Unauthorized(new
        //        {
        //            message = "Please login/register to purchase the course"
        //        });
        //    }



        //}

    }
}
