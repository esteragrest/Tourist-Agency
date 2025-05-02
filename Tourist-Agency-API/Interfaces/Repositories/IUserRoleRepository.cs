using TouristAgencyAPI.Entities;

namespace TouristAgencyAPI.Interfaces.Repositories
{
    public interface IUserRoleRepository
    {
        IEnumerable<UserRole> GetAll();
        UserRole? GetById(int id);
        UserRole Add(UserRole userRole);
        void Update(UserRole userRole);
        void Delete(int id);
    }
}
