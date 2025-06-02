using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TouristAgencyAPI.Entities;
using TouristAgencyAPI.Interfaces.Services;
using TouristAgencyAPI.Helpers;
using TouristAgencyAPI.Models;

namespace TouristAgencyAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _config;

        public AuthController(IUserService userService, IConfiguration config)
        {
            _userService = userService;
            _config = config;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] User user)
        {
            if (_userService.GetByEmail(user.Email) != null)
                return BadRequest("Пользователь уже существует");

            user.Password = PasswordHelper.HashPassword(user.Password);
            user.RoleId = user.RoleId == 0 ? 1 : user.RoleId;

            var newUser = _userService.Add(user);

            var token = JwtHelper.GenerateToken(newUser, _config);
            Response.Cookies.Append("jwt", token, new CookieOptions
            {
                HttpOnly = true,
                Secure = false,
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.UtcNow.AddHours(2)
            });

            return Ok(new { message = "Регистрация успешна!" });
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest loginRequest)
        {
            var foundUser = _userService.GetByEmail(loginRequest.Email);
            if (foundUser == null || !PasswordHelper.VerifyPassword(loginRequest.Password, foundUser.Password))
                return Unauthorized("Неверный email или пароль");

            var token = JwtHelper.GenerateToken(foundUser, _config);

            Response.Cookies.Append("jwt", token, new CookieOptions
            {
                HttpOnly = true,
                Secure = false,
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.UtcNow.AddHours(2)
            });

            return Ok(new { message = "Успешный вход" });
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt");
            return Ok(new { message = "Вы вышли из системы" });
        }
    }
}
