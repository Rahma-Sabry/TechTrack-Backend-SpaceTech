using System.ComponentModel.DataAnnotations;

namespace TechPathNavigator.Models
{
    public class SubCategory
    {
        [Key]
        public int SubCategoryId { get; set; }
        public int CategoryId { get; set; }
        public string? SubCategoryName { get; set; }
        public string? Description { get; set; }
        public string? DifficultyLevel { get; set; }
        public int EstimatedDuration { get; set; }

        [MaxLength(500)]
        public string? ImageUrl { get; set; }

        public Category? Category { get; set; }
        public ICollection<Track>? Tracks { get; set; }
    }
}
