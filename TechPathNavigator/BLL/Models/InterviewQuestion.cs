using System.ComponentModel.DataAnnotations;

namespace TechPathNavigator.Models
{
    public class InterviewQuestion
    {
        [Key]
        public int QuestionId { get; set; }

        public int TechnologyId { get; set; }
        public string? QuestionText { get; set; }
        public string? DifficultyLevel { get; set; }
        public string? QuestionType { get; set; } // behavioral, technical, etc.
        public string? SampleAnswer { get; set; }
        // Relationships
        public Technology? Technology { get; set; }
    }
}
