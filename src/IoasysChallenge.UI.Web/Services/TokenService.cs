using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Collections.Generic;
using System.Linq;
using Microsoft.IdentityModel.Tokens;
using IoasysChallenge.ApplicationCore.Entity;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace IoasysChallenge.UI.Web.Services
{
    public static  class TokenService
    {
        public static IConfiguration Configuration { get; set; }

        public static string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("ba29e0c3ed8be529ac37cc7da1f52cb4c3825bb88110d00fd891d947f8426c77");

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim (ClaimTypes.Name, user.UserName.ToString()),
                    new Claim (ClaimTypes.Role, user.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
