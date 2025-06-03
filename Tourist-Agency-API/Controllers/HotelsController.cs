using Microsoft.AspNetCore.Mvc;
using TouristAgencyAPI.Entities;
using TouristAgencyAPI.Interfaces.Repositories;
using TouristAgencyAPI.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace TouristAgencyAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelService _hotelService;
        private readonly IHotelRoomRepository _roomRepository;

        public HotelsController(IHotelService hotelService, IHotelRoomRepository roomRepository)
        {
            _hotelService = hotelService;
            _roomRepository = roomRepository;
        }

        // ��������� ������ ������ � �������� ���� �������������
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAll()
        {
            var hotels = _hotelService.GetAll();
            return Ok(hotels);
        }

        // ��������� ����������� ����� � ��� �������� (��������� ���� Rooms) � �������� ���� �������������
        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult GetById(int id)
        {
            var hotel = _hotelService.GetById(id);
            if (hotel == null)
                return NotFound();

            // �������� ������ ������� ��� ������� �����
            var rooms = _roomRepository.GetRoomsByHotelId(hotel.Id).ToList();

            // ��������� ��������� ������, ���������� ����� � �������������� ���� Rooms
            var result = new
            {
                hotel.Id,
                hotel.Title,
                hotel.Location,
                hotel.Description,
                hotel.Price,
                Rooms = rooms
            };

            return Ok(result);
        }

        // ����� ������ �� �������� � �������� ���� �������������
        [HttpGet("search/{query}")]
        [AllowAnonymous]
        public IActionResult SearchHotels(string query)
        {
            var hotels = _hotelService.SearchHotels(query);
            return Ok(hotels);
        }

        // ���������� ������ ����� � �������� ������ ���������� � ���������������
        [HttpPost]
        [Authorize(Roles = "manager,admin")]
        public IActionResult Add(Hotel hotel)
        {
            var newHotel = _hotelService.Add(hotel);
            return CreatedAtAction(nameof(GetById), new { id = newHotel.Id }, newHotel);
        }

        // ���������� ����� � �������� ������ ���������� � ���������������
        [HttpPut("{id}")]
        [Authorize(Roles = "manager,admin")]
        public IActionResult Update(int id, Hotel hotel)
        {
            if (id != hotel.Id)
                return BadRequest();
            _hotelService.Update(hotel);
            return NoContent();
        }

        // �������� ����� � �������� ������ ���������������
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult Delete(int id)
        {
            _hotelService.Delete(id);
            return NoContent();
        }
    }
}
