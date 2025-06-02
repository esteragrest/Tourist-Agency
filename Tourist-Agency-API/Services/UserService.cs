using TouristAgencyAPI.Entities;
using TouristAgencyAPI.Interfaces.Repositories;
using TouristAgencyAPI.Interfaces.Services;

namespace TouristAgencyAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<User> GetAll() => _repository.GetAll();

        public User? GetById(int id) => _repository.GetById(id);

        public User Add(User user) => _repository.Add(user);

        public void Update(User user) => _repository.Update(user);

        public void Delete(int id) => _repository.Delete(id);

        public User? GetByEmail(string email) => _repository.GetByEmail(email);
    }
}
