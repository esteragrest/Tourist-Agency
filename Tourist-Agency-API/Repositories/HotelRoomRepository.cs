using Microsoft.EntityFrameworkCore;
using TouristAgencyAPI.Entities;
using TouristAgencyAPI.Interfaces.Repositories;

namespace TouristAgencyAPI.Repositories
{
    public class HotelRoomRepository : IHotelRoomRepository
    {
        private readonly TouristAgencyContext _context;

        public HotelRoomRepository(TouristAgencyContext context)
        {
            _context = context;
        }

        public IEnumerable<HotelRoom> GetAll() => _context.HotelRooms.ToList();

        public HotelRoom? GetById(int id) => _context.HotelRooms.Find(id);

        public HotelRoom Add(HotelRoom hotelRoom)
        {
            _context.HotelRooms.Add(hotelRoom);
            _context.SaveChanges();
            return hotelRoom;
        }

        public void Update(HotelRoom hotelRoom)
        {
            _context.HotelRooms.Update(hotelRoom);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var hotelRoom = _context.HotelRooms.Find(id);
            if (hotelRoom != null)
            {
                _context.HotelRooms.Remove(hotelRoom);
                _context.SaveChanges();
            }
        }
    }
}
