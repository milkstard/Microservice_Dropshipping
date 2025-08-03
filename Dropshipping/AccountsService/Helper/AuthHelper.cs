using AccountsService.Models;
using AuthJWTClassLibrary;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AccountsService.Helper
{
    public class AuthHelper
    {
        public CustomedAuthenticationToken? GenerateAuthToken(Users user)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtExtensions.SecurityKey));
            //Signature
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var expirationTimeStamp = DateTime.Now.AddMinutes(5);

            //payload
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Name, user.UserName),
                new Claim("role", user.UserType.TypeName)
            };
            //Header and payload will implicitly goes to their own class with the use of JwtSecurityToken class
            var tokenOptions = new JwtSecurityToken(
                issuer: "https://localhost:7143",
                claims: claims,
                expires: expirationTimeStamp,
                signingCredentials: signingCredentials
                );

            //header base64, payload base64, signature HS256 with dots separator
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return new CustomedAuthenticationToken
            {
                Token = tokenString,
                ExpiresIn = (int)expirationTimeStamp.Subtract(DateTime.Now).TotalSeconds
            };
        }
    }
}
