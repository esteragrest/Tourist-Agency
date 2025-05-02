using Microsoft.AspNetCore.Mvc;
using TouristAgencyAPI.Entities;
using TouristAgencyAPI.Interfaces.Services;

namespace TouristAgencyAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserRolesController : ControllerBase
    {
        private readonly IUserRoleService _service;

        public UserRolesController(IUserRoleService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<UserRole> GetAll() => _service.GetAll();

        [HttpGet("{id}")]
        public ActionResult<UserRole> GetById(int id)
        {
            var role = _service.GetById(id);
            return role == null ? NotFound() : Ok(role);
        }

        [HttpPost]
        public ActionResult<UserRole> Add(UserRole role)
        {
            var newRole = _service.Add(role);
            return CreatedAtAction(nameof(GetById), new { id = newRole.Id }, newRole);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UserRole role)
        {
            if (id != role.Id) return BadRequest();
            _service.Update(role);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return NoContent();
        }
    }
}
