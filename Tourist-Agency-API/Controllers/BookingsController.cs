using Microsoft.AspNetCore.Mvc;
using TouristAgencyAPI.Entities;
using TouristAgencyAPI.Interfaces.Services;

namespace TouristAgencyAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _service;

        public BookingsController(IBookingService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Booking> GetAll() => _service.GetAll();

        [HttpGet("{id}")]
        public ActionResult<Booking> GetById(int id)
        {
            var booking = _service.GetById(id);
            return booking == null ? NotFound() : Ok(booking);
        }

        [HttpPost]
        public ActionResult<Booking> Add(Booking booking)
        {
            var newBooking = _service.Add(booking);
            return CreatedAtAction(nameof(GetById), new { id = newBooking.Id }, newBooking);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Booking booking)
        {
            if (id != booking.Id) return BadRequest();
            _service.Update(booking);
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
