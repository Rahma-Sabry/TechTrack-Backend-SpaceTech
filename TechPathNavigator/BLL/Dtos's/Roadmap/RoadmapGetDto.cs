namespace TechPathNavigator.DTOs
{
    public class RoadmapGetDto
    {
        public int RoadmapId { get; set; }
        public int TrackId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public List<RoadmapStepGetDto>? RoadmapSteps { get; set; }
    }

}
