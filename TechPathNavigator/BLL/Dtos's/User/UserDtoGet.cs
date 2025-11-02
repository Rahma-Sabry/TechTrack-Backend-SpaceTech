namespace TechPathNavigator.DTOs.User
{
    public class UserGetDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
