
namespace TechPathNavigator.DTOs
{
    public class SubCategoryPostDto
    {
        public string SubCategoryName { get; set; }
        public string Description { get; set; }
        public string DifficultyLevel { get; set; }
        public int EstimatedDuration { get; set; }
        public int CategoryId { get; set; } // link to parent category
    }
}