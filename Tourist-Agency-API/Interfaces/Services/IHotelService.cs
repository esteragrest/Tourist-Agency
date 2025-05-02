using TouristAgencyAPI.Entities;

namespace TouristAgencyAPI.Interfaces.Services
{
    public interface IHotelService
    {
        IEnumerable<Hotel> GetAll();
        Hotel? GetById(int id);
        Hotel Add(Hotel hotel);
        void Update(Hotel hotel);
        void Delete(int id);
    }
}
