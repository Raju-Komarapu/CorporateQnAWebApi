using CorporateQnA.Infrastructure.DbContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CorporateQnA.Services.Token
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        private readonly ApplicationDbContext _db;

        public TokenService(IConfiguration configuration, ApplicationDbContext db)
        {
            this._configuration = configuration;
            this._db = db;
        }

        public string GenerateToken(IdentityUser user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._configuration["Jwt:key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var query = "SELECT Id FROM Employee WHERE UserId = @userId";
            var employeeId = this._db.QuerySingleOrDefault<Guid>(query, new { userId = user.Id });

            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("UserId", employeeId.ToString())
            };

            var token = new JwtSecurityToken(
                            issuer: this._configuration["Jwt:Issuer"],
                            audience: this._configuration["Jwt:Audience"],
                            notBefore: DateTime.Now,
                            expires: DateTime.Now.AddHours(5),
                            claims: claims,
                            signingCredentials: credentials
                            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
