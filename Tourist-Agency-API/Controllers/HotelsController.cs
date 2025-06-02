using Microsoft.AspNetCore.Mvc;
using TouristAgencyAPI.Entities;
using TouristAgencyAPI.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;

namespace TouristAgencyAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelService _service;

        public HotelsController(IHotelService service)
        {
            _service = service;
        }

        // ѕолучение списка отелей Ц доступно всем пользовател€м
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Hotel> GetAll() => _service.GetAll();

        // ѕолучение конкретного отел€ по id Ц доступно всем пользовател€м
        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<Hotel> GetById(int id)
        {
            var hotel = _service.GetById(id);
            return hotel == null ? NotFound() : Ok(hotel);
        }

        // ƒобавление нового отел€ Ц доступно только менеджерам и администраторам
        [HttpPost]
        [Authorize(Roles = "manager,admin")]
        public ActionResult<Hotel> Add(Hotel hotel)
        {
            var newHotel = _service.Add(hotel);
            return CreatedAtAction(nameof(GetById), new { id = newHotel.Id }, newHotel);
        }

        // ќбновление отел€ Ц доступно только менеджерам и администраторам
        [HttpPut("{id}")]
        [Authorize(Roles = "manager,admin")]
        public IActionResult Update(int id, Hotel hotel)
        {
            if (id != hotel.Id)
                return BadRequest();
            _service.Update(hotel);
            return NoContent();
        }

        // ”даление отел€ Ц доступно только администраторам
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return NoContent();
        }
    }
}
