using Microsoft.AspNetCore.Mvc;
using TouristAgencyAPI.Entities;
using TouristAgencyAPI.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;


namespace TouristAgencyAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _service;

        public BookingsController(IBookingService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize(Roles = "manager,admin")]
        public IEnumerable<Booking> GetAll() => _service.GetAll();

        [HttpGet("{id}")]
        [Authorize(Roles = "user,manager,admin")]
        public ActionResult<Booking> GetById(int id)
        {
            var booking = _service.GetById(id);
            return booking == null ? NotFound() : Ok(booking);
        }


        [HttpPost]
        [Authorize(Roles = "user,manager,admin")] // Разрешаем добавление бронирования только зарегистрированным пользователям
        public ActionResult<Booking> Add(Booking booking)
        {
            var newBooking = _service.Add(booking);
            return CreatedAtAction(nameof(GetById), new { id = newBooking.Id }, newBooking);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "manager,admin")] // Редактировать могут только менеджеры и админы
        public IActionResult Update(int id, Booking booking)
        {
            if (id != booking.Id) return BadRequest();
            _service.Update(booking);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")] // Удалять бронирование может **только администратор**
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return NoContent();
        }
    }

}
