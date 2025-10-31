using Microsoft.AspNetCore.Mvc;
using TechPathNavigator.DTOs;
using TechPathNavigator.Services;

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
            if (tech == null) return NotFound();
            return Ok(tech);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TechnologyPostDto dto)
        {
            var created = await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.TechnologyId }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TechnologyPostDto dto)
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
