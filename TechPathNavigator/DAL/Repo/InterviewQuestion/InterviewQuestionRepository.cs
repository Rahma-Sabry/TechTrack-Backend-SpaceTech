using Microsoft.EntityFrameworkCore;
using TechPathNavigator.Data;
using TechPathNavigator.Models;

namespace TechPathNavigator.Repositories
{
    public class InterviewQuestionRepository : IGenericRepository<InterviewQuestion>, IInterviewQuestionRepository
    {
        private readonly ApplicationDbContext _context;

        public InterviewQuestionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<InterviewQuestion>> GetAllAsync()
        {
            return await _context.InterviewQuestions
                .Include(q => q.Technology)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<InterviewQuestion?> GetByIdAsync(int id)
        {
            return await _context.InterviewQuestions
                .Include(q => q.Technology)
                .FirstOrDefaultAsync(q => q.QuestionId == id);
        }

        public async Task<InterviewQuestion> AddAsync(InterviewQuestion question)
        {
            _context.InterviewQuestions.Add(question);
            await _context.SaveChangesAsync();
            return question;
        }

        public async Task<InterviewQuestion?> UpdateAsync(InterviewQuestion question)
        {
            var existing = await _context.InterviewQuestions.FindAsync(question.QuestionId);
            if (existing == null) return null;

            existing.TechnologyId = question.TechnologyId;
            existing.QuestionText = question.QuestionText;
            existing.DifficultyLevel = question.DifficultyLevel;
            existing.QuestionType = question.QuestionType;
            existing.SampleAnswer = question.SampleAnswer;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _context.InterviewQuestions.FindAsync(id);
            if (existing == null) return false;

            _context.InterviewQuestions.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> TechnologyExistsAsync(int technologyId)
        {
            return await _context.Technologies.AnyAsync(t => t.TechnologyId == technologyId);
        }
    }
}


