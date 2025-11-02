using System;
using Microsoft.AspNetCore.Mvc;
using TechPathNavigator.Common.Results;
using TechPathNavigator.DTOs;
using TechPathNavigator.Services;
using TechPathNavigator.Common.Messages;

namespace TechPathNavigator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InterviewQuestionController : ControllerBase
    {
        private readonly IInterviewQuestionService _service;

        public InterviewQuestionController(IInterviewQuestionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _service.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item == null) return NotFound(new { message = ApiMessages.InterviewQuestionNotFound });
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create(InterviewQuestionPostDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _service.CreateAsync(dto);
            if (!result.Success)
            {
                return BadRequest(new { errors = result.Errors });
            }

            return CreatedAtAction(nameof(GetById), new { id = result.Data!.QuestionId }, result.Data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, InterviewQuestionPostDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _service.UpdateAsync(id, dto);
            if (!result.Success)
            {
                if (result.Errors.Count == 1 && result.Errors[0].Contains("not found", StringComparison.OrdinalIgnoreCase))
                {
                    return NotFound(new { message = ApiMessages.InterviewQuestionNotFound });
                }
                return BadRequest(new { errors = result.Errors });
            }
            return Ok(result.Data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.DeleteAsync(id);
            if (!success) return NotFound(new { message = ApiMessages.InterviewQuestionNotFound });
            return NoContent();
        }
    }
}
