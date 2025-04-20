using TouristAgencyAPI.Entities;
using TouristAgencyAPI.Interfaces.Repositories;

namespace TouristAgencyAPI.Repositories
{
    public class TouristRouteRepository : ITouristRouteRepository
    {
        private readonly List<TouristRoute> _touristRoutes = new();

        public IEnumerable<TouristRoute> GetAll() => _touristRoutes;

        public TouristRoute? GetById(int id) => _touristRoutes.FirstOrDefault(r => r.Id == id);

        public TouristRoute Add(TouristRoute touristRoute)
        {
            touristRoute.Id = _touristRoutes.Count > 0 ? _touristRoutes.Max(r => r.Id) + 1 : 1;
            _touristRoutes.Add(touristRoute);
            return touristRoute;
        }

        public void Update(TouristRoute touristRoute)
        {
            var existingRoute = GetById(touristRoute.Id);
            if (existingRoute != null)
            {
                existingRoute.Title = touristRoute.Title;
                existingRoute.Description = touristRoute.Description;
                existingRoute.Duration = touristRoute.Duration;
                existingRoute.Price = touristRoute.Price;
            }
        }

        public void Delete(int id)
        {
            var route = GetById(id);
            if (route != null) _touristRoutes.Remove(route);
        }
    }
}