using TechPathNavigator.Models;

namespace TechPathNavigator.Repositories
{
    public interface IInterviewQuestionRepository : IGenericRepository<InterviewQuestion>
    {
       /* Task<IEnumerable<InterviewQuestion>> GetAllAsync();
        Task<InterviewQuestion?> GetByIdAsync(int id);
        Task<InterviewQuestion> AddAsync(InterviewQuestion question);
        Task<InterviewQuestion?> UpdateAsync(InterviewQuestion question);
        Task<bool> DeleteAsync(int id);
       */
        Task<bool> TechnologyExistsAsync(int technologyId);
    }
}


