using System.ComponentModel.DataAnnotations;

namespace TechPathNavigator.Models
{
    public class CompanyTechnology
    {
        [Key]
        public int CompanyTechnologyId { get; set; }

        public int CompanyId { get; set; }
        public int TechnologyId { get; set; }
        public string? UsageLevel { get; set; } // primary, secondary, experimental
        public string? Notes { get; set; }
        public Company? Company { get; set; }
        public Technology? Technology { get; set; }
    }
}
