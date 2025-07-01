using D2_Modul3.Data;
using D2_Modul3.Entities;
using D2_Modul3.Models;
using D2_Modul3.Session;
using D2_Modul3.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text.RegularExpressions;

namespace D2_Modul3.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private ApplicationDbContext dbContext;
        private PasswordHandler passwordHandler;
        private SessionHandler sessionHandler;

        public AuthController(ApplicationDbContext dbContext, PasswordHandler passwordHandler, SessionHandler sessionHandler)
        {
            this.dbContext = dbContext;
            this.passwordHandler = passwordHandler;
            this.sessionHandler = sessionHandler;
        }

        [HttpPost]
        [Route("/users/register")]
        public IActionResult Register([FromBody] RegisterDto registerDto)
        {
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

            var emailExists = dbContext.Users.Any(u => u.email == registerDto.email);
            if (emailExists)
            {
                return Conflict(new
                {
                    message = "User already registered."
                });
            }

            var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            if (!emailRegex.IsMatch(registerDto.email))
            {
                return BadRequest(new { 
                    message = "Validation error: email is invalid.."
                });
            }

            var passwordRegex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z0-9]).{8,}$");
            if (!passwordRegex.IsMatch(registerDto.password))
            {
                return BadRequest(new
                {
                    message = "Validation error: password must contain min. 8 chars with uppercase, lowercase, number, and symbol."
                });
            }

            var hashedPass = passwordHandler.HashPassword(registerDto.password);
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
            if(!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    message = "Validation error: invalid request body."
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

            var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            if (!emailRegex.IsMatch(loginDto.email))
            {
                return BadRequest(new { 
                    message = "Validation error: email format is invalid." 
                });
            }

            var hashedPass = passwordHandler.HashPassword(loginDto.password);
            var loggedUser = dbContext.Users.FirstOrDefault(u => u.email.Equals(loginDto.email) && u.password_hash.Equals(hashedPass));
            if (loggedUser == null)
            {
                return Unauthorized(new
                {
                    message = "Invalid email or password."
                });
            }

            var token = sessionHandler.GenerateToken(loggedUser);
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

        [HttpPost]
        [Authorize]
        [Route("/users/logout")]
        public IActionResult Logout()
        {
            var user = User.Identity?.IsAuthenticated;

            if (user == null)
            {
                return Unauthorized(new
                {
                    message = "Authorization token missing or invalid."
                });
            }

            return Ok(new
            {
                message = "Logout successful."
            });

        }

    }
}
