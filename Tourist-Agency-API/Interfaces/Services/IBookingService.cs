using TouristAgencyAPI.Entities;

namespace TouristAgencyAPI.Interfaces.Services
{
    public interface IBookingService
    {
        IEnumerable<Booking> GetAll();
        Booking? GetById(int id);
        Booking Add(Booking booking);
        void Update(Booking booking);
        void Delete(int id);
    }
}
