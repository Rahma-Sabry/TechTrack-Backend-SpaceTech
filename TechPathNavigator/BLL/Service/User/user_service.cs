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
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
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
            var user = new User
            {
                UserName = dto.UserName,
                Email = dto.Email,
                PasswordHash = dto.Password // ideally hash this before saving
            };

            var added = await _repo.AddAsync(user);

            return new UserGetDto
            {
                UserId = added.UserId,
                UserName = added.UserName,
                Email = added.Email
            };
        }

        public async Task<UserGetDto?> UpdateAsync(int id, UserUpdateDto dto)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return null;

            existing.UserName = dto.UserName ?? existing.UserName;
            existing.Email = dto.Email ?? existing.Email;
            if (!string.IsNullOrWhiteSpace(dto.Password))
                existing.PasswordHash = dto.Password; // ideally hash

            var updated = await _repo.UpdateAsync(existing);

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
    }
}
