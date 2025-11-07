using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        public async Task<IEnumerable<RoadmapStepGetDto>> GetAllByRoadmapId(int roadmapId)
        {
            return await _service.GetAllByRoadmapIdAsync(roadmapId);
        }

        [HttpGet("{id}")]
        public async Task<RoadmapStepGetDto> GetById(int id)
        {
            return await _service.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<RoadmapStepGetDto> Create([FromBody] RoadmapStepPostDto dto)
        {
            return await _service.AddAsync(dto);
        }

        [HttpPut("{id}")]
        public async Task<RoadmapStepGetDto> Update(int id, [FromBody] RoadmapStepPostDto dto)
        {
            return await _service.UpdateAsync(id, dto);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _service.DeleteAsync(id);
        }
    }
}
