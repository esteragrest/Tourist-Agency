using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TouristAgencyAPI.Entities;
using Microsoft.Extensions.Configuration;

namespace TouristAgencyAPI.Helpers
{
	public static class JwtHelper
	{
        public static string GenerateToken(User user, IConfiguration config)
        {
            var key = Encoding.UTF8.GetBytes(config["Jwt:Key"]);

            // Определяем роль пользователя по его RoleId
            string userRole = user.RoleId switch
            {
                1 => "user",
                3 => "manager",
                2 => "admin",
                _ => "user" // По умолчанию – если роль не распознана
            };

            var claims = new[]
            {
        new Claim(ClaimTypes.Name, user.Email),
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        new Claim(ClaimTypes.Role, userRole)
    };

            var token = new JwtSecurityToken(
                config["Jwt:Issuer"],
                config["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        public static ClaimsPrincipal? ValidateToken(string token, IConfiguration config)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.UTF8.GetBytes(config["Jwt:Key"]);

			try
			{
				return tokenHandler.ValidateToken(token, new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(key),
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidIssuer = config["Jwt:Issuer"],
					ValidAudience = config["Jwt:Audience"]
				}, out _);
			}
			catch
			{
				return null;
			}
		}
	}
}
