using TechPathNavigator.DTOs;
using TechPathNavigator.Models;

namespace TechPathNavigator.Extensions
{
    public static class CompanyMappingExtensions
    {
        public static CompanyGetDto ToGetDto(this Company entity)
        {
            return new CompanyGetDto
            {
                CompanyId = entity.CompanyId,
                CompanyName = entity.CompanyName,
                Industry = entity.Industry,
                WebsiteUrl = entity.WebsiteUrl,
                Description = entity.Description
            };
        }

        public static Company ToEntity(this CompanyPostDto dto, int? id = null)
        {
            return new Company
            {
                CompanyId = id ?? 0,
                CompanyName = dto.CompanyName,
                Industry = dto.Industry,
                WebsiteUrl = dto.WebsiteUrl,
                Description = dto.Description
            };
        }
    }
}


