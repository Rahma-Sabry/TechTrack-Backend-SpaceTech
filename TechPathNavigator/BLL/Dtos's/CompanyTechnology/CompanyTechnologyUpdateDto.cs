namespace TechPathNavigator.BLL.Dtos_s.CompanyTechnology
{
    public class CompanyTechnologyUpdateDto
    {
        public int? CompanyId { get; set; }
        public int? TechnologyId { get; set; }
        public string? UsageLevel { get; set; }
        public string? Notes { get; set; }
    }
}
