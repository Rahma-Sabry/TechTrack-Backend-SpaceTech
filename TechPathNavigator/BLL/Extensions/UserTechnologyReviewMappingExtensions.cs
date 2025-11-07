using TechPathNavigator.DTOs.Review;
using TechPathNavigator.Models;

namespace TechPathNavigator.Extensions
{
    public static class UserTechnologyReviewMappingExtensions
    {
        public static UserTechnologyReviewGetDto ToGetDto(this UserTechnologyReview entity)
        {
            return new UserTechnologyReviewGetDto
            {
                ReviewId = entity.ReviewId,
                UserId = entity.UserId,
                TechnologyId = entity.TechnologyId,
                Rating = entity.Rating,
                ReviewText = entity.ReviewText,
                UserName = entity.User?.UserName,
                TechnologyName = entity.Technology?.TechnologyName
            };
        }

        public static UserTechnologyReview ToEntity(this UserTechnologyReviewPostDto dto, int? id = null)
        {
            return new UserTechnologyReview
            {
                ReviewId = id ?? 0,
                UserId = dto.UserId,
                TechnologyId = dto.TechnologyId,
                Rating = dto.Rating,
                ReviewText = dto.ReviewText
            };
        }
    }
}


