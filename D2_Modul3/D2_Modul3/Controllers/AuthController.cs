using D2_Modul3.Data;
using D2_Modul3.Entities;
using D2_Modul3.Models;
using D2_Modul3.Session;
using D2_Modul3.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

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
        public IActionResult Register([FromBody] RegisterDto registerDto)
        {
            // validation
            if(!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    message = "Invalid request body."
                });
            }

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

        [HttpPost]
        [Route("/users/login")]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            // validation
            if(!ModelState.IsValid)
            {
                return Unauthorized(new
                {
                    message = "Invalid email or password."
                });
            }

            if (string.IsNullOrWhiteSpace(loginDto.email) || string.IsNullOrWhiteSpace(loginDto.password))
            {
                return BadRequest(new
                {
                    message = "Validation error: all fields are required."
                });
            }

            if (loginDto.password.Length < 8)
            {
                return BadRequest(new
                {
                    message = "Validation error: password must be at least 8 characters."
                });
            }

            var passHandler = new PasswordHandler();
            var hashedPass = passHandler.HashPassword(loginDto.password);

            var loggedUser = dbContext.Users.FirstOrDefault(u => u.email.Equals(loginDto.email) && u.password_hash.Equals(hashedPass));

            if (loggedUser == null)
            {
                return NotFound(new
                {
                    message = "User not found."
                });
            }

            var session = new SessionHandler();
            var token = session.GenerateToken(loggedUser);

            return Ok(new
            {
                message = "Login successful.",
                data = new
                {
                    userId = loggedUser.id,
                    username = loggedUser.username,
                    role = loggedUser.role,
                    token = token
                }
            });

        }

        //[HttpPost]
        //[Authorize]
        //[Route("/users/logout")]
        //public IActionResult Logout()
        //{
        //    var user = User.Identity?.IsAuthenticated;

        //    if (user == null)
        //    {
        //        return Unauthorized(new
        //        {
        //            message = "Authorization token missing or invalid."
        //        });
        //    }

            

        //}

    }
}
