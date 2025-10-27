namespace TechPathNavigator.Models
{
    public class Roadmap
    {
        public int RoadmapId { get; set; }
        public int TrackId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }

        public Track? Track { get; set; }
        public ICollection<RoadmapStep>? RoadmapSteps { get; set; }
    }
}
