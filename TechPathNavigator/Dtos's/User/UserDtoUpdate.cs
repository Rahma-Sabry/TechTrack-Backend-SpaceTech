namespace TechPathNavigator.DTOs.User
{


    public class UserUpdateDto
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }  // Optional password change
    }
}
