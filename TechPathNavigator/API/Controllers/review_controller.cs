using Microsoft.AspNetCore.Mvc;
using TechPathNavigator.DTOs.Review;
using TechPathNavigator.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TechPathNavigator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserTechnologyReviewController : ControllerBase
    {
        private readonly IUserTechnologyReviewService _service;

        public UserTechnologyReviewController(IUserTechnologyReviewService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<UserTechnologyReviewGetDto>> GetAll()
        {
            return await _service.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<UserTechnologyReviewGetDto> GetById(int id)
        {
            return await _service.GetByIdAsync(id);
        }

        [HttpGet("user/{userId}")]
        public async Task<IEnumerable<UserTechnologyReviewGetDto>> GetByUserId(int userId)
        {
            return await _service.GetByUserIdAsync(userId);
        }

        [HttpGet("technology/{technologyId}")]
        public async Task<IEnumerable<UserTechnologyReviewGetDto>> GetByTechnologyId(int technologyId)
        {
            return await _service.GetByTechnologyIdAsync(technologyId);
        }

        [HttpPost]
        public async Task<UserTechnologyReviewGetDto> Create([FromBody] UserTechnologyReviewPostDto dto)
        {
            var result = await _service.AddAsync(dto);
            return result.Data!;
        }

        [HttpPut("{id}")]
        public async Task<UserTechnologyReviewGetDto> Update(int id, [FromBody] UserTechnologyReviewPostDto dto)
        {
            var result = await _service.UpdateAsync(id, dto);
            return result.Data!;
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _service.DeleteAsync(id);
        }
    }
}
