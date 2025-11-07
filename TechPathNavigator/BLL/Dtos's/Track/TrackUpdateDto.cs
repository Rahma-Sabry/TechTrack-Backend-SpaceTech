namespace TechPathNavigator.BLL.Dtos_s.Track
{
    public class TrackUpdateDto
    {
        public int? SubCategoryId { get; set; }
        public string? TrackName { get; set; }
        public string? Description { get; set; }
        public string? DifficultyLevel { get; set; }
        public int? EstimatedDuration { get; set; }
    }
}
