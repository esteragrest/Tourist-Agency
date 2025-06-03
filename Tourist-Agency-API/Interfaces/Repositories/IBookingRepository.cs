using TouristAgencyAPI.Entities;

namespace TouristAgencyAPI.Interfaces.Repositories
{
    public interface IBookingRepository
    {
        IEnumerable<Booking> GetAll();
        IEnumerable<Booking> GetByUserId(int userId);
        IEnumerable<Booking> GetByHotelId(int hotelId);
        Booking? GetById(int id);
        Booking Add(Booking booking);
        void Update(Booking booking);
        void Delete(int id);
        bool IsRoomAvailable(int roomId, DateTime checkIn, DateTime checkOut);
    }
}
