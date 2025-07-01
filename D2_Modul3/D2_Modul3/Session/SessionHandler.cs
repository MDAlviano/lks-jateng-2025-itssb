using D2_Modul3.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace D2_Modul3.Session
{
    public class SessionHandler
    {
        public string GenerateToken(Users users)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, users.id.ToString()),
                new Claim(ClaimTypes.Email, users.email.ToString()),
                new Claim(ClaimTypes.Name, users.name.ToString()),
                new Claim(ClaimTypes.Role, users.role),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("lks-provinsi-jateng-2025-gsa-web-api-tp3"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "gsawebapi",
                audience: "gsawebapi",
                expires: DateTime.Now.AddDays(7),
                claims: claims,
                signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
