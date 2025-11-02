using Microsoft.AspNetCore.Mvc;
using TechPathNavigator.DTOs;
using TechPathNavigator.Services;
using TechPathNavigator.Common.Messages;

namespace TechPathNavigator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrackController : ControllerBase
    {
        private readonly TrackService _service;

        public TrackController(TrackService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var track = await _service.GetByIdAsync(id);
            if (track == null) return NotFound(new { message = ApiMessages.TrackNotFound });
            return Ok(track);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TrackPostDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.TrackId }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TrackPostDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _service.UpdateAsync(id, dto);
            if (updated == null) return NotFound(new { message = ApiMessages.TrackNotFound });
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.DeleteAsync(id);
            if (!success) return NotFound(new { message = ApiMessages.TrackNotFound });
            return NoContent();
        }
    }
}
