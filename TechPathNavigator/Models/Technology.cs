using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TechPathNavigator.Models
{
    public class Technology
    {
        [Key]
        public int TechnologyId { get; set; }

        [Required]
        public int TrackId { get; set; }
        public Track Track { get; set; }

        [Required, MaxLength(200)]
        public string TechnologyName { get; set; }

        public string Description { get; set; }

        [MaxLength(500)]
        public string? VideoUrl { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
