using System.Collections.Generic;
using TouristAgencyAPI.Entities;

namespace TouristAgencyAPI.Interfaces.Repositories
{
    public interface IHotelRepository
    {
        IEnumerable<Hotel> GetAll();
        IEnumerable<Hotel> SearchHotels(string query);
        Hotel? GetById(int id);
        Hotel Add(Hotel hotel);
        void Update(Hotel hotel);
        void Delete(int id);
    }
}
