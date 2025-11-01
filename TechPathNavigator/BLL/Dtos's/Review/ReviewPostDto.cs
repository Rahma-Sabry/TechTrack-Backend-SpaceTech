namespace TechPathNavigator.DTOs.Review
{
    public class UserTechnologyReviewPostDto
    {
        public int UserId { get; set; }
        public int TechnologyId { get; set; }
        public int Rating { get; set; }  // e.g., 1-5 stars
        public string? ReviewText { get; set; }
    }
}
