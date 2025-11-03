using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechPathNavigator.DTOs;
using TechPathNavigator.Services;

namespace TechPathNavigator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyTechnologyController : ControllerBase
    {
        private readonly ICompanyTechnologyService _service;

        public CompanyTechnologyController(ICompanyTechnologyService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<CompanyTechnologyGetDto>> GetAll()
        {
            return await _service.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<CompanyTechnologyGetDto> GetById(int id)
        {
            return await _service.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<CompanyTechnologyGetDto> Create([FromBody] CompanyTechnologyPostDto dto)
        {
            var result = await _service.CreateAsync(dto);
            return result.Data!;
        }

        [HttpPut("{id}")]
        public async Task<CompanyTechnologyGetDto> Update(int id, [FromBody] CompanyTechnologyPostDto dto)
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
