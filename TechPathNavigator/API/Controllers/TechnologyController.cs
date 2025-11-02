using Microsoft.AspNetCore.Mvc;
using TechPathNavigator.DTOs;
using TechPathNavigator.Services;
using TechPathNavigator.Common.Messages;

namespace TechPathNavigator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TechnologyController : ControllerBase
    {
        private readonly TechnologyService _service;

        public TechnologyController(TechnologyService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var techs = await _service.GetAllAsync();
            return Ok(techs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var tech = await _service.GetByIdAsync(id);
            if (tech == null) return NotFound(new { message = ApiMessages.TechnologyNotFound });
            return Ok(tech);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TechnologyPostDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.TechnologyId }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TechnologyPostDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _service.UpdateAsync(id, dto);
            if (updated == null) return NotFound(new { message = ApiMessages.TechnologyNotFound });
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.DeleteAsync(id);
            if (!success) return NotFound(new { message = ApiMessages.TechnologyNotFound });
            return NoContent();
        }
    }
}
