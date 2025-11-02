using TechPathNavigator.DTOs;
using TechPathNavigator.DTOs.User;
using TechPathNavigator.Models;
using TechPathNavigator.Repositories;
using TechPathNavigator.Service.User;

namespace TechPathNavigator.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;

        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<UserGetDto>> GetAllAsync()
        {
            var users = await _repo.GetAllAsync();
            return users.Select(u => new UserGetDto
            {
                UserId = u.UserId,
                UserName = u.UserName,
                Email = u.Email
            });
        }

        public async Task<UserGetDto?> GetByIdAsync(int id)
        {
            var user = await _repo.GetByIdAsync(id);
            if (user == null) return null;

            return new UserGetDto
            {
                UserId = user.UserId,
                UserName = user.UserName,
                Email = user.Email
            };
        }

        public async Task<UserGetDto?> GetByEmailAsync(string email)
        {
            var user = await _repo.GetByEmailAsync(email);
            if (user == null) return null;

            return new UserGetDto
            {
                UserId = user.UserId,
                UserName = user.UserName,
                Email = user.Email
            };
        }

        public async Task<UserGetDto> AddAsync(UserPostDto dto)
        {
            // TODO: Hash password properly using BCrypt or similar
            var entity = new User
            {
                UserName = dto.UserName,
                Email = dto.Email,
                PasswordHash = HashPassword(dto.Password)  // Simple hash for now
            };

            var added = await _repo.AddAsync(entity);

            return new UserGetDto
            {
                UserId = added.UserId,
                UserName = added.UserName,
                Email = added.Email
            };
        }

        public async Task<UserGetDto?> UpdateAsync(int id, UserUpdateDto dto)
        {
            var entity = new User
            {
                UserId = id,
                UserName = dto.UserName,
                Email = dto.Email,
                PasswordHash = !string.IsNullOrEmpty(dto.Password) ? HashPassword(dto.Password) : null
            };

            var updated = await _repo.UpdateAsync(entity);
            if (updated == null) return null;

            return new UserGetDto
            {
                UserId = updated.UserId,
                UserName = updated.UserName,
                Email = updated.Email
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repo.DeleteAsync(id);
        }

        // Simple password hashing - replace with BCrypt.Net-Next in production
        private string? HashPassword(string? password)
        {
            if (string.IsNullOrEmpty(password)) return null;

            // TODO: Replace with proper password hashing (BCrypt, Argon2, etc.)
            // For now, just a simple base64 encoding (NOT SECURE - DEMO ONLY)
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }
}
