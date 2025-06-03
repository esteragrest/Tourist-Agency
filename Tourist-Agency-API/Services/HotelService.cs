using System.Collections.Generic;
using TouristAgencyAPI.Entities;
using TouristAgencyAPI.Interfaces.Repositories;
using TouristAgencyAPI.Interfaces.Services;

namespace TouristAgencyAPI.Services
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelService(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public IEnumerable<Hotel> GetAll()
        {
            return _hotelRepository.GetAll();
        }

        public IEnumerable<Hotel> SearchHotels(string query)
        {
            return _hotelRepository.SearchHotels(query);
        }

        public Hotel? GetById(int id) => _hotelRepository.GetById(id);

        public Hotel Add(Hotel hotel) => _hotelRepository.Add(hotel);

        public void Update(Hotel hotel) => _hotelRepository.Update(hotel);

        public void Delete(int id) => _hotelRepository.Delete(id);
    }
}
