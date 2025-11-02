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
    public class TrackController : ControllerBase
    {
        private readonly TrackService _service;

        public TrackController(TrackService service)
        {
            _service = service;
        }

        [HttpGet]
<<<<<<< HEAD
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());
=======
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }
>>>>>>> osama

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var track = await _service.GetByIdAsync(id);
<<<<<<< HEAD
            if (track == null) return NotFound();
=======
            if (track == null) return NotFound(new { message = ApiMessages.TrackNotFound });
>>>>>>> osama
            return Ok(track);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TrackPostDto dto)
        {
<<<<<<< HEAD
=======
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

>>>>>>> osama
            var created = await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.TrackId }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TrackPostDto dto)
        {
<<<<<<< HEAD
            var updated = await _service.UpdateAsync(id, dto);
            if (updated == null) return NotFound();
=======
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _service.UpdateAsync(id, dto);
            if (updated == null) return NotFound(new { message = ApiMessages.TrackNotFound });
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
            if (!success) return NotFound(new { message = ApiMessages.TrackNotFound });
>>>>>>> osama
            return NoContent();
        }
    }
}
