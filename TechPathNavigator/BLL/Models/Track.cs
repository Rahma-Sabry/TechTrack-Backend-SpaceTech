namespace TechPathNavigator.Models
{
    public class Track
    {
        public int TrackId { get; set; }
        public int SubCategoryId { get; set; }
        public string? TrackName { get; set; }
        public string? Description { get; set; }
        public string? DifficultyLevel { get; set; }
        public int EstimatedDuration { get; set; } // in hours
        public SubCategory? SubCategory { get; set; }
        public ICollection<Technology>? Technologies { get; set; }
    }
}