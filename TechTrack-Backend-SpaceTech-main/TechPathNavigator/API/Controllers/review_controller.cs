using System;
using Microsoft.AspNetCore.Mvc;
using TechPathNavigator.DTOs;
using TechPathNavigator.DTOs.Review;
using TechPathNavigator.Services;
using TechPathNavigator.Common.Messages;

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
        public async Task<IActionResult> GetAll()
        {
            var reviews = await _service.GetAllAsync();
            return Ok(reviews);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var review = await _service.GetByIdAsync(id);
            if (review == null) return NotFound(new { message = ApiMessages.ReviewNotFound });
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
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _service.AddAsync(dto);
            if (!result.Success) return BadRequest(new { errors = result.Errors });
            return CreatedAtAction(nameof(GetById), new { id = result.Data!.ReviewId }, result.Data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UserTechnologyReviewPostDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _service.UpdateAsync(id, dto);
            if (!result.Success)
            {
                if (result.Errors.Count == 1 && result.Errors[0].Contains("not found", StringComparison.OrdinalIgnoreCase))
                    return NotFound(new { message = ApiMessages.ReviewNotFound });
                return BadRequest(new { errors = result.Errors });
            }
            return Ok(result.Data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.DeleteAsync(id);
            if (!success) return NotFound(new { message = ApiMessages.ReviewNotFound });
            return NoContent();
        }
    }
}
