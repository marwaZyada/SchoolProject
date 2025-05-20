using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using School.Domain.Entities.Authentication;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace School.Infrastructure.Service
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<string> CreateTokenAsync(ApplicationUser user)
        {
            var authclaims = new List<Claim>()
           {
               new Claim(ClaimTypes.Name,user.UserName),
               new Claim(ClaimTypes.Email,user.Email)

           };
            // security key
            var authkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));

            // registed claim
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issure"],
                audience: _configuration["JWT:Audience"],
                expires:DateTime.UtcNow.AddDays(double.Parse (_configuration["JWT:ExpireDate"])),
                claims:authclaims,
                signingCredentials:new SigningCredentials(authkey,SecurityAlgorithms.HmacSha256Signature)
            );
            return new JwtSecurityTokenHandler().WriteToken( token);

        }
    }
}
