using Microsoft.AspNetCore.Mvc;
using TouristAgencyAPI.Entities;
using TouristAgencyAPI.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;

namespace TouristAgencyAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize] // ¬се эндпоинты требуют авторизации
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;

        public UsersController(IUserService service)
        {
            _service = service;
        }

        // ѕолучение списка пользователей Ц доступно только дл€ admin и manager
        [HttpGet]
        [Authorize(Roles = "admin,manager")]
        public IEnumerable<User> GetAll() => _service.GetAll();

        // ѕолучение конкретного пользовател€ по Id Ц доступно только дл€ admin и manager
        [HttpGet("{id}")]
        [Authorize(Roles = "admin,manager")]
        public ActionResult<User> GetById(int id)
        {
            var user = _service.GetById(id);
            return user == null ? NotFound() : Ok(user);
        }

        // —оздание нового пользовател€ Ц доступно только дл€ admin и manager
        [HttpPost]
        [Authorize(Roles = "admin,manager")]
        public ActionResult<User> Add(User user)
        {
            var newUser = _service.Add(user);
            return CreatedAtAction(nameof(GetById), new { id = newUser.Id }, newUser);
        }

        // ќбновление пользовател€ Ц доступно только дл€ admin и manager
        [HttpPut("{id}")]
        [Authorize(Roles = "admin,manager")]
        public IActionResult Update(int id, User user)
        {
            if (id != user.Id)
                return BadRequest();
            _service.Update(user);
            return NoContent();
        }

        // ”даление пользовател€ Ц доступно только дл€ admin
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return NoContent();
        }
    }
}
