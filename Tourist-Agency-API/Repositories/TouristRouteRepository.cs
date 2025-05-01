using Microsoft.EntityFrameworkCore;
using TouristAgencyAPI.Entities;
using TouristAgencyAPI.Interfaces.Repositories;

namespace TouristAgencyAPI.Repositories
{
    public class TouristRouteRepository : ITouristRouteRepository
    {
        private readonly TouristAgencyContext _context;

        public TouristRouteRepository(TouristAgencyContext context)
        {
            _context = context;
        }

        public IEnumerable<TouristRoute> GetAll() => _context.TouristRoutes.ToList();

        public TouristRoute? GetById(int id) => _context.TouristRoutes.Find(id);

        public TouristRoute Add(TouristRoute touristRoute)
        {
            _context.TouristRoutes.Add(touristRoute);
            _context.SaveChanges();
            return touristRoute;
        }

        public void Update(TouristRoute touristRoute)
        {
            _context.TouristRoutes.Update(touristRoute);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var route = _context.TouristRoutes.Find(id);
            if (route != null)
            {
                _context.TouristRoutes.Remove(route);
                _context.SaveChanges();
            }
        }
    }
}
