using Microsoft.AspNetCore.Mvc;
using TouristAgencyAPI.Entities;
using TouristAgencyAPI.Interfaces.Services;

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

        [HttpGet]
        public IEnumerable<HotelRoom> GetAll() => _service.GetAll();

        [HttpGet("{id}")]
        public ActionResult<HotelRoom> GetById(int id)
        {
            var hotelRoom = _service.GetById(id);
            return hotelRoom == null ? NotFound() : Ok(hotelRoom);
        }

        [HttpPost]
        public ActionResult<HotelRoom> Add(HotelRoom hotelRoom)
        {
            var newRoom = _service.Add(hotelRoom);
            return CreatedAtAction(nameof(GetById), new { id = newRoom.Id }, newRoom);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, HotelRoom hotelRoom)
        {
            if (id != hotelRoom.Id) return BadRequest();
            _service.Update(hotelRoom);
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
