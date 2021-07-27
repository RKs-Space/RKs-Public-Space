using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace UserService.Service
{
    /*
     * This class should implement JWT token validation method declared by ITokenGeneratorService
     * Option Pattern should be implemented for reading token details from config file
     */

    public class TokenGeneratorService : ITokenGeneratorService
    {
        public string GetJWTToken(string UserId)
        {
            var claims = new[] { new Claim("UserId", UserId) };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("secret_auth_microservice"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: "UserAuthenticationServer",
                audience: "UserClient",
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(20),
                signingCredentials: creds
                );
            var response = new { token = new JwtSecurityTokenHandler().WriteToken(token) };
            return JsonConvert.SerializeObject(response);
            //throw new System.NotImplementedException();
        }
    }
}
