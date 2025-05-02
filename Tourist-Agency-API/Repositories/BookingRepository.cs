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
    }
}
