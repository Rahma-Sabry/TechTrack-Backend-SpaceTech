using System.ComponentModel.DataAnnotations;

namespace TechPathNavigator.Models
{
    public class UserTechnologyReview
    {
        [Key]
        public int ReviewId { get; set; }

        public int UserId { get; set; }
        public int TechnologyId { get; set; }
        public int Rating { get; set; }
        public string? ReviewText { get; set; }
        public string? ExperienceLevel { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // relationships
        public Technology? Technology { get; set; }
        public User? User { get; set; }
    }
}
