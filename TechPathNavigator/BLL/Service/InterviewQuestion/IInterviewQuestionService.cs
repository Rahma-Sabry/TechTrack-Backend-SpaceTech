using TechPathNavigator.Common.Results;
using TechPathNavigator.DTOs;

namespace TechPathNavigator.Services
{
    public interface IInterviewQuestionService
    {
        Task<IEnumerable<InterviewQuestionGetDto>> GetAllAsync();
        Task<InterviewQuestionGetDto?> GetByIdAsync(int id);
        Task<ServiceResult<InterviewQuestionGetDto>> CreateAsync(InterviewQuestionPostDto dto);
        Task<ServiceResult<InterviewQuestionGetDto>> UpdateAsync(int id, InterviewQuestionPostDto dto);
        Task<bool> DeleteAsync(int id);
    }
}


