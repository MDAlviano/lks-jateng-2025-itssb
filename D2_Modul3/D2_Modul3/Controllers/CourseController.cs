using D2_Modul3.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        [Route("/course")]
        public IActionResult GetCourses([FromQuery] string? title)
        {
            var courses = (from c in dbContext.Courses
                           select c).ToList();

            if (title != null)
            {
                var getCourseByTitle = (from c in dbContext.Courses
                                        where c.title.Contains(title)
                                        select c).ToList();

                return Ok(new
                {
                    data = getCourseByTitle
                });

            }

            return Ok(new
            {
                data = courses
            });

        }

    }
}
