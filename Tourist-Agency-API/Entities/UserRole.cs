using System.ComponentModel.DataAnnotations;

namespace TouristAgencyAPI.Entities
{
    public class UserRole
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
