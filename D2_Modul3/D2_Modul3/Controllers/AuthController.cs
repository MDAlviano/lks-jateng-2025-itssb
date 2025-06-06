using D2_Modul3.Data;
using D2_Modul3.Entities;
using D2_Modul3.Models;
using D2_Modul3.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace D2_Modul3.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private ApplicationDbContext dbContext;

        public AuthController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        [Route("/users/register")]
        public IActionResult Register(RegisterDto registerDto)
        {
            if (string.IsNullOrWhiteSpace(registerDto.username) || string.IsNullOrWhiteSpace(registerDto.fullName) || string.IsNullOrWhiteSpace(registerDto.email) || string.IsNullOrWhiteSpace(registerDto.password))
            {
                return BadRequest(new
                {
                    message = "Validation error: email is required!"
                });
            }

            var security = new PasswordHandler();
            var hashedPass = security.HashPassword(registerDto.password);

            Users newUser = new Users
            {
                name = registerDto.fullName,
                username = registerDto.username,
                email = registerDto.email,
                password_hash = hashedPass,
                role = "student",
                created_at = DateTime.Now,
            };

            dbContext.Users.Add(newUser);
            dbContext.SaveChanges();

            return Ok(new
            {
                message = "User registered successfully"
            });

        }

    }
}
