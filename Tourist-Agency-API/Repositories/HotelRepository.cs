using Microsoft.EntityFrameworkCore;
using TouristAgencyAPI.Entities;
using TouristAgencyAPI.Interfaces.Repositories;

namespace TouristAgencyAPI.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly TouristAgencyContext _context;

        public HotelRepository(TouristAgencyContext context)
        {
            _context = context;
        }

        public IEnumerable<Hotel> GetAll() => _context.Hotels.ToList();

        public Hotel? GetById(int id) => _context.Hotels.Find(id);

        public Hotel Add(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            _context.SaveChanges();
            return hotel;
        }

        public void Update(Hotel hotel)
        {
            _context.Hotels.Update(hotel);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var hotel = _context.Hotels.Find(id);
            if (hotel != null)
            {
                _context.Hotels.Remove(hotel);
                _context.SaveChanges();
            }
        }
    }
}
