using Microsoft.AspNetCore.Mvc;
using TechPathNavigator.DTOs;
using TechPathNavigator.Services;

namespace TechPathNavigator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoadmapStepController : ControllerBase
    {
        private readonly RoadmapStepService _service;

        public RoadmapStepController(RoadmapStepService service)
        {
            _service = service;
        }

        [HttpGet("roadmap/{roadmapId}")]
        public async Task<IActionResult> GetAllByRoadmapId(int roadmapId)
        {
            var steps = await _service.GetAllByRoadmapIdAsync(roadmapId);
            return Ok(steps);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var step = await _service.GetByIdAsync(id);
            if (step == null) return NotFound();
            return Ok(step);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoadmapStepPostDto dto)
        {
            var created = await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.RoadmapStepId }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, RoadmapStepPostDto dto)
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
