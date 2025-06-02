using TouristAgencyAPI.Entities;

namespace TouristAgencyAPI.Interfaces.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User? GetById(int id);
        User Add(User user);
        void Update(User user);
        void Delete(int id);

        User? GetByEmail(string email);
    }
}
