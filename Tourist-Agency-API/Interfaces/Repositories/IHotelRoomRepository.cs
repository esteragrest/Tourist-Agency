using System.Collections.Generic;
using TouristAgencyAPI.Entities;

namespace TouristAgencyAPI.Interfaces.Repositories
{
    public interface IHotelRoomRepository
    {
        IEnumerable<HotelRoom> GetAll();
        IEnumerable<HotelRoom> GetRoomsByHotelId(int hotelId);
        HotelRoom? GetById(int id);
        HotelRoom Add(HotelRoom hotelRoom);
        void Update(HotelRoom hotelRoom);
        void Delete(int id);
    }
}
