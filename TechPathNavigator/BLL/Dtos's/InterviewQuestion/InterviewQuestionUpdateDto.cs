namespace TechPathNavigator.BLL.Dtos_s.InterviewQuestion
{
    public class InterviewQuestionUpdateDto
    {
        public string? QuestionText { get; set; }
        public string? Answer { get; set; }
        public int? DifficultyLevel { get; set; }
        public int? CategoryId { get; set; }
    }
}
