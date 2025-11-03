namespace TechPathNavigator.BLL.Dtos_s.RoadMapStep
{
    public class RoadmapStepUpdateDto
    {
        public int? RoadmapId { get; set; }
        public string? StepTitle { get; set; }
        public string? StepDescription { get; set; }
        public int? StepOrder { get; set; }
    }
}
