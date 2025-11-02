using Microsoft.AspNetCore.Mvc;
using TechPathNavigator.DTOs;
using TechPathNavigator.Services;
using TechPathNavigator.Common.Messages;

namespace TechPathNavigator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoadmapController : ControllerBase
    {
        private readonly RoadmapService _service;

        public RoadmapController(RoadmapService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var roadmaps = await _service.GetAllAsync();
            return Ok(roadmaps);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var roadmap = await _service.GetByIdAsync(id);
            if (roadmap == null)
                return NotFound(new { message = ApiMessages.RoadmapNotFound });
            return Ok(roadmap);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoadmapPostDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.RoadmapId }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, RoadmapPostDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _service.UpdateAsync(id, dto);
            if (updated == null)
                return NotFound(new { message = ApiMessages.RoadmapNotFound });
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.DeleteAsync(id);
            if (!success)
                return NotFound(new { message = ApiMessages.RoadmapNotFound });
            return NoContent();
        }
    }
}
