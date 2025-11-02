namespace TechPathNavigator.DTOs
{
    public class SubCategoryGetDto
    {
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public string Description { get; set; }
        public string DifficultyLevel { get; set; }
        public int EstimatedDuration { get; set; }
        public string? ImageUrl { get; set; }

        // Optional: Include Category info
        public int CategoryId { get; set; }
    }
}
