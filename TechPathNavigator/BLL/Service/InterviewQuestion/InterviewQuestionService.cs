using TechPathNavigator.Common.Errors;
using TechPathNavigator.Common.Results;
using TechPathNavigator.DTOs;
using TechPathNavigator.Extensions;
using TechPathNavigator.Repositories;

namespace TechPathNavigator.Services
{
    public class InterviewQuestionService : IInterviewQuestionService
    {
        private static readonly HashSet<string> AllowedDifficulties = new(StringComparer.OrdinalIgnoreCase) { "Easy", "Medium", "Hard" };
        private static readonly HashSet<string> AllowedTypes = new(StringComparer.OrdinalIgnoreCase) { "Technical", "Behavioral", "SystemDesign" };

        private readonly IInterviewQuestionRepository _repository;

        public InterviewQuestionService(IInterviewQuestionRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<InterviewQuestionGetDto>> GetAllAsync()
        {
            var items = await _repository.GetAllAsync();
            return items.Select(i => i.ToGetDto());
        }

        public async Task<InterviewQuestionGetDto?> GetByIdAsync(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            return item?.ToGetDto();
        }

        public async Task<ServiceResult<InterviewQuestionGetDto>> CreateAsync(InterviewQuestionPostDto dto)
        {
            var validationErrors = await Validate(dto);
            if (validationErrors.Any()) return ServiceResult<InterviewQuestionGetDto>.Fail(validationErrors);

            var entity = dto.ToEntity();
            var created = await _repository.AddAsync(entity);
            return ServiceResult<InterviewQuestionGetDto>.Ok(created.ToGetDto());
        }

        public async Task<ServiceResult<InterviewQuestionGetDto>> UpdateAsync(int id, InterviewQuestionPostDto dto)
        {
            var validationErrors = await Validate(dto);
            if (validationErrors.Any()) return ServiceResult<InterviewQuestionGetDto>.Fail(validationErrors);

            var updated = await _repository.UpdateAsync(dto.ToEntity(id));
            if (updated == null) return ServiceResult<InterviewQuestionGetDto>.Fail("Interview question not found.");

            return ServiceResult<InterviewQuestionGetDto>.Ok(updated.ToGetDto());
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        private async Task<List<string>> Validate(InterviewQuestionPostDto dto)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(dto.QuestionText))
            {
                errors.Add(ErrorMessages.InterviewQuestion_TextRequired);
            }

            if (!await _repository.TechnologyExistsAsync(dto.TechnologyId))
            {
                errors.Add(ErrorMessages.InterviewQuestion_TechnologyRequired);
            }

            if (!string.IsNullOrWhiteSpace(dto.DifficultyLevel) && !AllowedDifficulties.Contains(dto.DifficultyLevel))
            {
                errors.Add(ErrorMessages.InterviewQuestion_DifficultyInvalid);
            }

            if (!string.IsNullOrWhiteSpace(dto.QuestionType) && !AllowedTypes.Contains(dto.QuestionType))
            {
                errors.Add(ErrorMessages.InterviewQuestion_TypeInvalid);
            }

            return errors;
        }
    }
}


