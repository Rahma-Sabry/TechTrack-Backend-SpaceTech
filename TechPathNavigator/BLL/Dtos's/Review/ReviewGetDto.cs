namespace TechPathNavigator.DTOs.Review
{

    public class UserTechnologyReviewGetDto
    {
        public int ReviewId { get; set; }
        public int UserId { get; set; }
        public int TechnologyId { get; set; }
        public int Rating { get; set; }
        public string? ReviewText { get; set; }

        // Optional: Include user and technology names
        public string? UserName { get; set; }
        public string? TechnologyName { get; set; }
    }
}
