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
<<<<<<< HEAD
            if (roadmap == null) return NotFound();
=======
            if (roadmap == null) return NotFound(new { message = ApiMessages.RoadmapNotFound });
>>>>>>> osama
            return Ok(roadmap);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoadmapPostDto dto)
        {
<<<<<<< HEAD
=======
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

>>>>>>> osama
            var created = await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.RoadmapId }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, RoadmapPostDto dto)
        {
<<<<<<< HEAD
            var updated = await _service.UpdateAsync(id, dto);
            if (updated == null) return NotFound();
=======
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _service.UpdateAsync(id, dto);
            if (updated == null) return NotFound(new { message = ApiMessages.RoadmapNotFound });
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
            if (!success) return NotFound(new { message = ApiMessages.RoadmapNotFound });
>>>>>>> osama
            return NoContent();
        }
    }
}
