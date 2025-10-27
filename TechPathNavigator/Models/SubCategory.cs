namespace TechPathNavigator.Models
{
    public class SubCategory
    {
        public int SubCategoryId { get; set; }
        public int CategoryId { get; set; }
        public string? SubCategoryName { get; set; }
        public string? Description { get; set; }
        public string? DifficultyLevel { get; set; }
        public int EstimatedDuration { get; set; }
        public Category? Category { get; set; }
        public ICollection<Track>? Tracks { get; set; }
    }
}
