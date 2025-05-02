using TouristAgencyAPI.Entities;

namespace TouristAgencyAPI.Interfaces.Repositories
{
    public interface IBookingRepository
    {
        IEnumerable<Booking> GetAll();
        Booking? GetById(int id);
        Booking Add(Booking booking);
        void Update(Booking booking);
        void Delete(int id);
    }
}
