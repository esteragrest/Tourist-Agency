using System.ComponentModel.DataAnnotations;

namespace TouristAgencyAPI.Entities
{
    public class HotelRoom
    {
        public int Id { get; set; }

        [Required]
        public int HotelId { get; set; }

        [Required]
        [MaxLength(50)]
        public string RoomType { get; set; } = string.Empty;

        [Required]
        [Range(1, 10)]
        public int GuestsCapacity { get; set; }

        [MaxLength(300)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public bool IsAvailable { get; set; }
    }
}
