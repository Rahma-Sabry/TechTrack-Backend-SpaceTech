using TechPathNavigator.DTOs.User;
using TechPathNavigator.Models;
using TechPathNavigator.Repositories;

namespace TechPathNavigator.Service.User
{
    public interface IUserService
    {
        Task<IEnumerable<UserGetDto>> GetAllAsync();
        Task<UserGetDto?> GetByIdAsync(int id);
        Task<UserGetDto> AddAsync(UserPostDto dto);
        Task<UserGetDto?> UpdateAsync(int id, UserUpdateDto dto);
        Task<bool> DeleteAsync(int id);
        Task<UserGetDto?> GetByEmailAsync(string email);
    }
}
