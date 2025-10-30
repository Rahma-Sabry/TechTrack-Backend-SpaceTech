using Microsoft.AspNetCore.Mvc;
using TechPathNavigator.DTOs;
using TechPathNavigator.Service.Technology;

namespace TechPathNavigator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TechnologyController : ControllerBase
    {
        private readonly ITechnologyService _service;

        public TechnologyController(ITechnologyService service)
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
            return Ok(await _service.GetByIdAsync(id));
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
            return Ok(await _service.UpdateAsync(id, dto));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
