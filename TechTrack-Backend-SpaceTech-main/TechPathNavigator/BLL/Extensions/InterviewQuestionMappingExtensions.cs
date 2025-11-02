using TechPathNavigator.DTOs;
using TechPathNavigator.Models;

namespace TechPathNavigator.Extensions
{
    public static class InterviewQuestionMappingExtensions
    {
        public static InterviewQuestionGetDto ToGetDto(this InterviewQuestion entity)
        {
            return new InterviewQuestionGetDto
            {
                QuestionId = entity.QuestionId,
                TechnologyId = entity.TechnologyId,
                QuestionText = entity.QuestionText,
                DifficultyLevel = entity.DifficultyLevel,
                QuestionType = entity.QuestionType,
                SampleAnswer = entity.SampleAnswer
            };
        }

        public static InterviewQuestion ToEntity(this InterviewQuestionPostDto dto, int? id = null)
        {
            return new InterviewQuestion
            {
                QuestionId = id ?? 0,
                TechnologyId = dto.TechnologyId,
                QuestionText = dto.QuestionText,
                DifficultyLevel = dto.DifficultyLevel,
                QuestionType = dto.QuestionType,
                SampleAnswer = dto.SampleAnswer
            };
        }
    }
}


