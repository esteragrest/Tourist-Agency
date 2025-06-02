using Microsoft.AspNetCore.Mvc;
using TouristAgencyAPI.Entities;
using TouristAgencyAPI.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;

namespace TouristAgencyAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HotelRoomsController : ControllerBase
    {
        private readonly IHotelRoomService _service;

        public HotelRoomsController(IHotelRoomService service)
        {
            _service = service;
        }

        // ѕросмотр списка номеров Ц доступен всем
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<HotelRoom> GetAll() => _service.GetAll();

        // ѕросмотр информации о конкретном номере Ц доступен всем
        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<HotelRoom> GetById(int id)
        {
            var hotelRoom = _service.GetById(id);
            return hotelRoom == null ? NotFound() : Ok(hotelRoom);
        }

        // ƒобавление нового номера Ц разрешено только менеджерам и администраторам
        [HttpPost]
        [Authorize(Roles = "manager,admin")]
        public ActionResult<HotelRoom> Add(HotelRoom hotelRoom)
        {
            var newRoom = _service.Add(hotelRoom);
            return CreatedAtAction(nameof(GetById), new { id = newRoom.Id }, newRoom);
        }

        // –едактирование номера Ц разрешено только менеджерам и администраторам
        [HttpPut("{id}")]
        [Authorize(Roles = "manager,admin")]
        public IActionResult Update(int id, HotelRoom hotelRoom)
        {
            if (id != hotelRoom.Id)
                return BadRequest();
            _service.Update(hotelRoom);
            return NoContent();
        }

        // ”даление номера Ц разрешено только администраторам
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return NoContent();
        }
    }
}
