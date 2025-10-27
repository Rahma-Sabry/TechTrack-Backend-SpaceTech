using System.ComponentModel.DataAnnotations;

namespace TechPathNavigator.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; }

        public ICollection<UserTechnologyReview>? Reviews { get; set; }
    }
}
