using Microsoft.AspNetCore.Mvc;
using TechPathNavigator.DTOs.User;
using TechPathNavigator.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TechPathNavigator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _service;

        public UserController(UserService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<UserGetDto>> GetAll()
        {
            return await _service.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<UserGetDto> GetById(int id)
        {
            return await _service.GetByIdAsync(id);
        }

        [HttpGet("email/{email}")]
        public async Task<UserGetDto> GetByEmail(string email)
        {
            return await _service.GetByEmailAsync(email);
        }

        [HttpPost]
        public async Task<UserGetDto> Create([FromBody] UserPostDto dto)
        {
            return await _service.AddAsync(dto);
        }

        [HttpPut("{id}")]
        public async Task<UserGetDto> Update(int id, [FromBody] UserUpdateDto dto)
        {
            return await _service.UpdateAsync(id, dto);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _service.DeleteAsync(id);
        }
    }
}
