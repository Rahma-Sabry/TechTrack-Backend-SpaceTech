using System.ComponentModel.DataAnnotations;

namespace TechPathNavigator.Models
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }

        public string? CompanyName { get; set; }
        public string? Industry { get; set; }
        public string? WebsiteUrl { get; set; }
        public string? CompanySize { get; set; }
        public string? Headquarters { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }

        public ICollection<CompanyTechnology>? CompanyTechnologies { get; set; }

      

    }
}
