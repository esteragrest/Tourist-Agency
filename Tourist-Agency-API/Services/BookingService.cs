using TouristAgencyAPI.Entities;
using TouristAgencyAPI.Interfaces.Repositories;
using TouristAgencyAPI.Interfaces.Services;

namespace TouristAgencyAPI.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _repository;
        private readonly IHotelRepository _hotelRepository;
        private readonly IHotelRoomRepository _roomRepository;

        public BookingService(IBookingRepository repository, IHotelRepository hotelRepository, IHotelRoomRepository roomRepository)
        {
            _repository = repository;
            _hotelRepository = hotelRepository;
            _roomRepository = roomRepository;
        }

        public IEnumerable<Booking> GetAll() => _repository.GetAll();

        public IEnumerable<Booking> GetUserBookings(int userId) => _repository.GetByUserId(userId);

        public IEnumerable<Booking> GetBookingsByHotel(int hotelId)
        {
            var hotelExists = _hotelRepository.GetById(hotelId);
            if (hotelExists == null) return new List<Booking>();

            return _repository.GetByHotelId(hotelId);
        }

        public Booking? GetById(int id) => _repository.GetById(id);

        public Booking? Add(Booking booking, int userId)
        {
            var hotelExists = _hotelRepository.GetById(booking.HotelId);
            if (hotelExists == null) return null;

            var roomExists = _roomRepository.GetById(booking.RoomId);
            if (roomExists == null) return null;

            bool roomAvailable = _repository.IsRoomAvailable(booking.RoomId, booking.CheckInDate, booking.CheckOutDate);
            if (!roomAvailable) return null;

            booking.UserId = userId;
            return _repository.Add(booking);
        }

        public void Update(Booking booking) => _repository.Update(booking);

        public bool Delete(int id, int userId, bool isAdmin)
        {
            var booking = _repository.GetById(id);
            if (booking == null) return false;

            if (booking.UserId != userId && !isAdmin) return false;

            _repository.Delete(id);
            return true;
        }
    }
}
