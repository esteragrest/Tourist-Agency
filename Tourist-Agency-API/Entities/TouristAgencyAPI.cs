using System.ComponentModel.DataAnnotations;

namespace TouristAgencyAPI.Entities
{
    public class Hotel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(150)]
        public string Location { get; set; } = string.Empty;

        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Range(10, 10000)]
        public decimal Price { get; set; }

        [Required]
        [Range(1, 500)]
        public int RoomsCount { get; set; }

        [Required]
        [Range(0, 500)]
        public int AvailableRooms { get; set; }

        [Url]
        public string Image { get; set; } = string.Empty;
    }
}
