namespace TechPathNavigator.DTOs
{
    public class CompanyTechnologyGetDto
    {
        public int CompanyTechnologyId { get; set; }
        public int CompanyId { get; set; }
        public int TechnologyId { get; set; }
        public string? UsageLevel { get; set; }
        public string? Notes { get; set; }
        public string? CompanyName { get; set; }
        public string? TechnologyName { get; set; }
    }
}


