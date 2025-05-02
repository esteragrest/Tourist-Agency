using TouristAgencyAPI.Entities;
using TouristAgencyAPI.Interfaces.Repositories;
using TouristAgencyAPI.Interfaces.Services;

namespace TouristAgencyAPI.Services
{
    public class HotelRoomService : IHotelRoomService
    {
        private readonly IHotelRoomRepository _repository;

        public HotelRoomService(IHotelRoomRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<HotelRoom> GetAll() => _repository.GetAll();

        public HotelRoom? GetById(int id) => _repository.GetById(id);

        public HotelRoom Add(HotelRoom hotelRoom) => _repository.Add(hotelRoom);

        public void Update(HotelRoom hotelRoom) => _repository.Update(hotelRoom);

        public void Delete(int id) => _repository.Delete(id);
    }
}
