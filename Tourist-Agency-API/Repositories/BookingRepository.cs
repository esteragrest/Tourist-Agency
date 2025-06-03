using Microsoft.EntityFrameworkCore;
using TouristAgencyAPI.Entities;
using TouristAgencyAPI.Interfaces.Repositories;

namespace TouristAgencyAPI.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly TouristAgencyContext _context;

        public BookingRepository(TouristAgencyContext context)
        {
            _context = context;
        }

        public IEnumerable<Booking> GetAll() => _context.Bookings.ToList();

        public IEnumerable<Booking> GetByUserId(int userId) => _context.Bookings.Where(b => b.UserId == userId).ToList();

        public IEnumerable<Booking> GetByHotelId(int hotelId) => _context.Bookings.Where(b => b.HotelId == hotelId).ToList();

        public Booking? GetById(int id) => _context.Bookings.Find(id);

        public Booking Add(Booking booking)
        {
            _context.Bookings.Add(booking);
            _context.SaveChanges();
            return booking;
        }

        public void Update(Booking booking)
        {
            _context.Bookings.Update(booking);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var booking = _context.Bookings.Find(id);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                _context.SaveChanges();
            }
        }

        public bool IsRoomAvailable(int roomId, DateTime checkIn, DateTime checkOut)
        {
            return !_context.Bookings.Any(b =>
                b.RoomId == roomId &&
                ((b.CheckInDate <= checkOut && b.CheckOutDate >= checkIn)));
        }
    }
}
