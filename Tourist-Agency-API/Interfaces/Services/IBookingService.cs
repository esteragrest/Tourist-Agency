using TouristAgencyAPI.Entities;

namespace TouristAgencyAPI.Interfaces.Services
{
    public interface IBookingService
    {
        IEnumerable<Booking> GetAll();
        IEnumerable<Booking> GetUserBookings(int userId);
        IEnumerable<Booking> GetBookingsByHotel(int hotelId);
        Booking? GetById(int id);
        Booking? Add(Booking booking, int userId);
        void Update(Booking booking);
        bool Delete(int id, int userId, bool isAdmin);
    }
}
