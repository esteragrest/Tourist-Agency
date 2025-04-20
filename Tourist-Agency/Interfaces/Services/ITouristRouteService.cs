using TouristAgencyAPI.Entities;

namespace TouristAgencyAPI.Interfaces.Services
{
    public interface ITouristRouteService
    {
        IEnumerable<TouristRoute> GetAll();
        TouristRoute? GetById(int id);
        TouristRoute Add(TouristRoute touristRoute);
        void Update(TouristRoute touristRoute);
        void Delete(int id);
    }
}