using TouristAgencyAPI.Entities;
using TouristAgencyAPI.Interfaces.Repositories;
using TouristAgencyAPI.Interfaces.Services;

namespace TouristAgencyAPI.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _repository;

        public BookingService(IBookingRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Booking> GetAll() => _repository.GetAll();

        public Booking? GetById(int id) => _repository.GetById(id);

        public Booking Add(Booking booking) => _repository.Add(booking);

        public void Update(Booking booking) => _repository.Update(booking);

        public void Delete(int id) => _repository.Delete(id);
    }
}
