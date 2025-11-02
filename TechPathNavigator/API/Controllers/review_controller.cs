<<<<<<< HEAD
=======
using System;
>>>>>>> osama
using Microsoft.AspNetCore.Mvc;
using TechPathNavigator.DTOs;
using TechPathNavigator.DTOs.Review;
using TechPathNavigator.Services;
<<<<<<< HEAD
=======
using TechPathNavigator.Common.Messages;
>>>>>>> osama

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
<<<<<<< HEAD
            if (review == null) return NotFound();
=======
            if (review == null) return NotFound(new { message = ApiMessages.ReviewNotFound });
>>>>>>> osama
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
<<<<<<< HEAD
=======
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

>>>>>>> osama
            var result = await _service.AddAsync(dto);
            if (!result.Success) return BadRequest(new { errors = result.Errors });
            return CreatedAtAction(nameof(GetById), new { id = result.Data!.ReviewId }, result.Data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UserTechnologyReviewPostDto dto)
        {
<<<<<<< HEAD
=======
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

>>>>>>> osama
            var result = await _service.UpdateAsync(id, dto);
            if (!result.Success)
            {
                if (result.Errors.Count == 1 && result.Errors[0].Contains("not found", StringComparison.OrdinalIgnoreCase))
<<<<<<< HEAD
                    return NotFound();
=======
                    return NotFound(new { message = ApiMessages.ReviewNotFound });
>>>>>>> osama
                return BadRequest(new { errors = result.Errors });
            }
            return Ok(result.Data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.DeleteAsync(id);
<<<<<<< HEAD
            if (!success) return NotFound();
=======
            if (!success) return NotFound(new { message = ApiMessages.ReviewNotFound });
>>>>>>> osama
            return NoContent();
        }
    }
}
