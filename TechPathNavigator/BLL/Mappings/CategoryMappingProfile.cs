using AutoMapper;
using TechPathNavigator.DTOs;
using TechPathNavigator.Models;

namespace TechPathNavigator.BLL.Mappings
{
    /// <summary>
    /// AutoMapper profile for Category entity mappings
    /// Defines bidirectional mappings between entities and DTOs
    /// </summary>
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            // Entity to DTO
            CreateMap<Category, CategoryGetDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.CategoryName))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));

            // DTO to Entity
            CreateMap<CategoryPostDto, Category>()
                .ForMember(dest => dest.CategoryId, opt => opt.Ignore())
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.SubCategories, opt => opt.Ignore());
        }
    }
}
