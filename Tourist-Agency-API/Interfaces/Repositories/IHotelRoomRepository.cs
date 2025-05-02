using TouristAgencyAPI.Entities;

namespace TouristAgencyAPI.Interfaces.Repositories
{
    public interface IHotelRoomRepository
    {
        IEnumerable<HotelRoom> GetAll();
        HotelRoom? GetById(int id);
        HotelRoom Add(HotelRoom hotelRoom);
        void Update(HotelRoom hotelRoom);
        void Delete(int id);
    }
}
