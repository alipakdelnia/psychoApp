using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace psychoApp.Services
{
    public class TokenService
    {

        private readonly string _key;
        private readonly string _issuer;
        private readonly string _audience;

        

        public TokenService(IConfiguration configuration)
        {
            _key = configuration["JwtSettings:Key"];
            _issuer = configuration["JwtSettings:Issuer"];
            _audience = configuration["JwtSettings:Audience"];
        }

        public string GenerateToken(string username)
        {

            var claims = new[]{
            new Claim(ClaimTypes.Name ,username),
            new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}