using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechPathNavigator.DTOs;
using TechPathNavigator.Services;

namespace TechPathNavigator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InterviewQuestionController : ControllerBase
    {
        private readonly IInterviewQuestionService _service;

        public InterviewQuestionController(IInterviewQuestionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<InterviewQuestionGetDto>> GetAll()
        {
            return await _service.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<InterviewQuestionGetDto> GetById(int id)
        {
            return await _service.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<InterviewQuestionGetDto> Create([FromBody] InterviewQuestionPostDto dto)
        {
            var result = await _service.CreateAsync(dto);
            return result.Data!;
        }

        [HttpPut("{id}")]
        public async Task<InterviewQuestionGetDto> Update(int id, [FromBody] InterviewQuestionPostDto dto)
        {
            var result = await _service.UpdateAsync(id, dto);
            return result.Data!;
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _service.DeleteAsync(id);
        }
    }
}
