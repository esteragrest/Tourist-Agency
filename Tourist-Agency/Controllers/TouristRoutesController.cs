using Microsoft.AspNetCore.Mvc;
using TouristAgencyAPI.Entities;
using TouristAgencyAPI.Interfaces.Services;

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

        [HttpGet]
        public IEnumerable<TouristRoute> GetAll() => _service.GetAll();

        [HttpGet("{id}")]
        public ActionResult<TouristRoute> GetById(int id)
        {
            var touristRoute = _service.GetById(id);
            return touristRoute == null ? NotFound() : Ok(touristRoute);
        }

        [HttpPost]
        public ActionResult<TouristRoute> Add(TouristRoute touristRoute)
        {
            var newTouristRoute = _service.Add(touristRoute);
            return CreatedAtAction(nameof(GetById), new { id = newTouristRoute.Id }, newTouristRoute);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, TouristRoute touristRoute)
        {
            if (id != touristRoute.Id) return BadRequest();
            _service.Update(touristRoute);
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