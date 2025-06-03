using Microsoft.AspNetCore.Mvc;
using TouristAgencyAPI.Entities;
using TouristAgencyAPI.Interfaces.Services;
using TouristAgencyAPI.Interfaces.Repositories;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace TouristAgencyAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _service;
        private readonly IHotelRepository _hotelRepository;

        public BookingsController(IBookingService service, IHotelRepository hotelRepository)
        {
            _service = service;
            _hotelRepository = hotelRepository;
        }

        [HttpGet]
        [Authorize(Roles = "manager,admin")]
        public IEnumerable<Booking> GetAll() => _service.GetAll();

        [HttpGet("my-bookings")]
        [Authorize(Roles = "user")]
        public ActionResult<IEnumerable<Booking>> GetUserBookings()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
            return Ok(_service.GetUserBookings(userId));
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "user,manager,admin")]
        public ActionResult<Booking> GetById(int id)
        {
            var booking = _service.GetById(id);
            return booking == null ? NotFound() : Ok(booking);
        }

        [HttpGet("hotel/{hotelId}")]
        [Authorize(Roles = "manager,admin")]
        public ActionResult<IEnumerable<Booking>> GetBookingsByHotel(int hotelId)
        {
            var hotelExists = _hotelRepository.GetById(hotelId);
            if (hotelExists == null) return NotFound("Ошибка: указанный отель не найден.");

            var bookings = _service.GetBookingsByHotel(hotelId);
            return Ok(bookings);
        }

        [HttpPost]
        [Authorize(Roles = "user,manager,admin")]
        public ActionResult<Booking> Add(Booking booking)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
            var newBooking = _service.Add(booking, userId);

            if (newBooking == null)
                return BadRequest("Ошибка: номер не существует, отель не найден или номер уже забронирован на эти даты.");

            return CreatedAtAction(nameof(GetById), new { id = newBooking.Id }, newBooking);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "user,admin")]
        public IActionResult Delete(int id)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
            bool isAdmin = User.IsInRole("admin");

            bool success = _service.Delete(id, userId, isAdmin);
            return success ? NoContent() : Unauthorized("Вы можете удалить только свою бронь.");
        }
    }
}
