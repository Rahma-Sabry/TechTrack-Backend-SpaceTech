using TechPathNavigator.DTOs;
using TechPathNavigator.DTOs.User;
using TechPathNavigator.Models;

namespace TechPathNavigator.Extensions
{
    public static class UserMappingExtensions
    {
        // Entity → GetDto
        public static UserGetDto ToGetDto(this User user)
        {
            return new UserGetDto
            {
                UserId = user.UserId,
                UserName = user.UserName,
                Email = user.Email
            };
        }

        // PostDto → Entity
        public static User ToEntity(this UserPostDto dto)
        {
            return new User
            {
                UserName = dto.UserName,
                Email = dto.Email,
                PasswordHash = dto.Password != null ? HashPassword(dto.Password) : null
            };
        }

        // UpdateDto → Entity
        public static User ToEntity(this UserUpdateDto dto, int id)
        {
            return new User
            {
                UserId = id,
                UserName = dto.UserName,
                Email = dto.Email,
                PasswordHash = !string.IsNullOrEmpty(dto.Password) ? HashPassword(dto.Password) : null
            };
        }

        // Simple hashing for demo (replace with BCrypt/Argon2)
        private static string? HashPassword(string? password)
        {
            if (string.IsNullOrEmpty(password)) return null;
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }
}
