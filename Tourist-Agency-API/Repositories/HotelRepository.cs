using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<Hotel> GetAll()
        {
            return _context.Hotels.ToList();
        }

        public IEnumerable<Hotel> SearchHotels(string query)
        {
            return _context.Hotels
                .Where(h => EF.Functions.Like(h.Title.ToLower(), $"%{query.ToLower()}%"))
                .ToList();
        }

        public Hotel? GetById(int id)
        {
            return _context.Hotels.Find(id);
        }

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
