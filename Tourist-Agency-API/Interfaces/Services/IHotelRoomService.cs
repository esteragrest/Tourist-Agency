using TouristAgencyAPI.Entities;

namespace TouristAgencyAPI.Interfaces.Services
{
    public interface IHotelRoomService
    {
        IEnumerable<HotelRoom> GetAll();
        HotelRoom? GetById(int id);
        HotelRoom Add(HotelRoom hotelRoom);
        void Update(HotelRoom hotelRoom);
        void Delete(int id);
    }
}
