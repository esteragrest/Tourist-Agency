using TouristAgencyAPI.Entities;

namespace TouristAgencyAPI.Interfaces.Services
{
    public interface IUserRoleService
    {
        IEnumerable<UserRole> GetAll();
        UserRole? GetById(int id);
        UserRole Add(UserRole userRole);
        void Update(UserRole userRole);
        void Delete(int id);
    }
}
