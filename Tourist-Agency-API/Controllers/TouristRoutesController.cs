using Microsoft.AspNetCore.Mvc;
using TouristAgencyAPI.Entities;
using TouristAgencyAPI.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;

namespace TouristAgencyAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TouristRoutesController : ControllerBase
    {
        private readonly ITouristRouteService _service;

        public TouristRoutesController(ITouristRouteService service)
        {
            _service = service;
        }

        // Получить все туристические маршруты – доступно всем пользователям
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<TouristRoute> GetAll() => _service.GetAll();

        // Получить конкретный туристический маршрут по Id – доступно всем пользователям
        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<TouristRoute> GetById(int id)
        {
            var touristRoute = _service.GetById(id);
            return touristRoute == null ? NotFound() : Ok(touristRoute);
        }

        // Добавление нового маршрута – доступно только менеджерам и администраторам
        [HttpPost]
        [Authorize(Roles = "manager,admin")]
        public ActionResult<TouristRoute> Add(TouristRoute touristRoute)
        {
            var newTouristRoute = _service.Add(touristRoute);
            return CreatedAtAction(nameof(GetById), new { id = newTouristRoute.Id }, newTouristRoute);
        }

        // Обновление маршрута – доступно только менеджерам и администраторам
        [HttpPut("{id}")]
        [Authorize(Roles = "manager,admin")]
        public IActionResult Update(int id, TouristRoute touristRoute)
        {
            if (id != touristRoute.Id)
                return BadRequest();

            _service.Update(touristRoute);
            return NoContent();
        }

        // Удаление маршрута – доступно только администраторам
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return NoContent();
        }
    }
}
