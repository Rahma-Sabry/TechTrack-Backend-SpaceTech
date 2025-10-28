using Microsoft.AspNetCore.Mvc;
using TechPathNavigator.DTOs;
using TechPathNavigator.DTOs.Review;
using TechPathNavigator.Services;

namespace TechPathNavigator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserTechnologyReviewController : ControllerBase
    {
        private readonly UserTechnologyReviewService _service;

        public UserTechnologyReviewController(UserTechnologyReviewService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var reviews = await _service.GetAllAsync();
            return Ok(reviews);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var review = await _service.GetByIdAsync(id);
            if (review == null) return NotFound();
            return Ok(review);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            var reviews = await _service.GetByUserIdAsync(userId);
            return Ok(reviews);
        }

        [HttpGet("technology/{technologyId}")]
        public async Task<IActionResult> GetByTechnologyId(int technologyId)
        {
            var reviews = await _service.GetByTechnologyIdAsync(technologyId);
            return Ok(reviews);
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserTechnologyReviewPostDto dto)
        {
            var created = await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.ReviewId }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UserTechnologyReviewPostDto dto)
        {
            var updated = await _service.UpdateAsync(id, dto);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.DeleteAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
