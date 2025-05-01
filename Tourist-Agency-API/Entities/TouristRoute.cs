﻿using System.ComponentModel.DataAnnotations;

namespace TouristAgencyAPI.Entities
{
    public class TouristRoute
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public int Duration { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}