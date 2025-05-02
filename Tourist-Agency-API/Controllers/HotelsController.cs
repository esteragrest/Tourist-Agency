using Microsoft.AspNetCore.Mvc;
using TouristAgencyAPI.Entities;
using TouristAgencyAPI.Interfaces.Services;

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

        [HttpGet]
        public IEnumerable<Hotel> GetAll() => _service.GetAll();

        [HttpGet("{id}")]
        public ActionResult<Hotel> GetById(int id)
        {
            var hotel = _service.GetById(id);
            return hotel == null ? NotFound() : Ok(hotel);
        }

        [HttpPost]
        public ActionResult<Hotel> Add(Hotel hotel)
        {
            var newHotel = _service.Add(hotel);
            return CreatedAtAction(nameof(GetById), new { id = newHotel.Id }, newHotel);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Hotel hotel)
        {
            if (id != hotel.Id) return BadRequest();
            _service.Update(hotel);
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
