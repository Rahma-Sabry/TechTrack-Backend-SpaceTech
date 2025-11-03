using TechPathNavigator.DTOs;
using TechPathNavigator.Models;

namespace TechPathNavigator.Extensions
{
    public static class CompanyTechnologyMappingExtensions
    {
        public static CompanyTechnologyGetDto ToGetDto(this CompanyTechnology entity)
        {
            return new CompanyTechnologyGetDto
            {
                CompanyTechnologyId = entity.CompanyTechnologyId,
                CompanyId = entity.CompanyId,
                TechnologyId = entity.TechnologyId,
                UsageLevel = entity.UsageLevel,
                Notes = entity.Notes,
                CompanyName = entity.Company?.CompanyName,
                TechnologyName = entity.Technology?.TechnologyName
            };
        }

        public static CompanyTechnology ToEntity(this CompanyTechnologyPostDto dto, int? id = null)
        {
            return new CompanyTechnology
            {
                CompanyTechnologyId = id ?? 0,
                CompanyId = dto.CompanyId,
                TechnologyId = dto.TechnologyId,
                UsageLevel = dto.UsageLevel,
                Notes = dto.Notes
            };
        }
    }
}


