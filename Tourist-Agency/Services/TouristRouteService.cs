using TouristAgencyAPI.Entities;
using TouristAgencyAPI.Interfaces.Repositories;
using TouristAgencyAPI.Interfaces.Services;

namespace TouristAgencyAPI.Services
{
    public class TouristRouteService : ITouristRouteService
    {
        private readonly ITouristRouteRepository _repository;

        public TouristRouteService(ITouristRouteRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<TouristRoute> GetAll() => _repository.GetAll();

        public TouristRoute? GetById(int id) => _repository.GetById(id);

        public TouristRoute Add(TouristRoute touristRoute) => _repository.Add(touristRoute);

        public void Update(TouristRoute touristRoute) => _repository.Update(touristRoute);

        public void Delete(int id) => _repository.Delete(id);
    }
}