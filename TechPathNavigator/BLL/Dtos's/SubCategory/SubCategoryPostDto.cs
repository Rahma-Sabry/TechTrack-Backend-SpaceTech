
namespace TechPathNavigator.DTOs
{
    public class SubCategoryPostDto
    {
        public string? SubCategoryName { get; set; }
        public string? Description { get; set; }
        public int? CategoryId { get; set; }           // nullable
        public int? DifficultyLevel { get; set; }     // nullable
        public int? EstimatedDuration { get; set; }   // nullable
        public string? ImageUrl { get; set; }
    }

}
