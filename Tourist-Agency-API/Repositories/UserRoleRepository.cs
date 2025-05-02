using Microsoft.EntityFrameworkCore;
using TouristAgencyAPI.Entities;
using TouristAgencyAPI.Interfaces.Repositories;

namespace TouristAgencyAPI.Repositories
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly TouristAgencyContext _context;

        public UserRoleRepository(TouristAgencyContext context)
        {
            _context = context;
        }

        public IEnumerable<UserRole> GetAll() => _context.UserRoles.ToList();

        public UserRole? GetById(int id) => _context.UserRoles.Find(id);

        public UserRole Add(UserRole userRole)
        {
            _context.UserRoles.Add(userRole);
            _context.SaveChanges();
            return userRole;
        }

        public void Update(UserRole userRole)
        {
            _context.UserRoles.Update(userRole);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var role = _context.UserRoles.Find(id);
            if (role != null)
            {
                _context.UserRoles.Remove(role);
                _context.SaveChanges();
            }
        }
    }
}
