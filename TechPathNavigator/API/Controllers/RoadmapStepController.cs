using Microsoft.AspNetCore.Mvc;
using TechPathNavigator.DTOs;
using TechPathNavigator.Services;
<<<<<<< HEAD
=======
using TechPathNavigator.Common.Messages;
>>>>>>> osama

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
<<<<<<< HEAD
            if (step == null) return NotFound();
=======
            if (step == null) return NotFound(new { message = ApiMessages.RoadmapStepNotFound });
>>>>>>> osama
            return Ok(step);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoadmapStepPostDto dto)
        {
<<<<<<< HEAD
=======
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

>>>>>>> osama
            var created = await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.RoadmapStepId }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, RoadmapStepPostDto dto)
        {
<<<<<<< HEAD
            var updated = await _service.UpdateAsync(id, dto);
            if (updated == null) return NotFound();
=======
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _service.UpdateAsync(id, dto);
            if (updated == null) return NotFound(new { message = ApiMessages.RoadmapStepNotFound });
>>>>>>> osama
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.DeleteAsync(id);
<<<<<<< HEAD
            if (!success) return NotFound();
=======
            if (!success) return NotFound(new { message = ApiMessages.RoadmapStepNotFound });
>>>>>>> osama
            return NoContent();
        }
    }
}
