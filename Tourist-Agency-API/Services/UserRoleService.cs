using TouristAgencyAPI.Entities;
using TouristAgencyAPI.Interfaces.Repositories;
using TouristAgencyAPI.Interfaces.Services;

namespace TouristAgencyAPI.Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IUserRoleRepository _repository;

        public UserRoleService(IUserRoleRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<UserRole> GetAll() => _repository.GetAll();

        public UserRole? GetById(int id) => _repository.GetById(id);

        public UserRole Add(UserRole userRole) => _repository.Add(userRole);

        public void Update(UserRole userRole) => _repository.Update(userRole);

        public void Delete(int id) => _repository.Delete(id);
    }
}
