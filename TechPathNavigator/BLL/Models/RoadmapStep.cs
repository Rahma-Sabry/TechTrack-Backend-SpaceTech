namespace TechPathNavigator.Models
{
    public class RoadmapStep
    {
        public int RoadmapStepId { get; set; }
        public int RoadmapId { get; set; }
        public string? StepTitle { get; set; }
        public string? StepDescription { get; set; }
        public int StepOrder { get; set; }
        public Roadmap? Roadmap { get; set; }
    }
}
