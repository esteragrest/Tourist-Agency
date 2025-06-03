using System.Collections.Generic;
using TouristAgencyAPI.Entities;

namespace TouristAgencyAPI.Interfaces.Services
{
    public interface IHotelService
    {
        IEnumerable<Hotel> GetAll();
        IEnumerable<Hotel> SearchHotels(string query);
        Hotel? GetById(int id);
        Hotel Add(Hotel hotel);
        void Update(Hotel hotel);
        void Delete(int id);
    }
}
