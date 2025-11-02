using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechPathNavigator.DTOs;
using TechPathNavigator.Services;

namespace TechPathNavigator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _service;

        public CompanyController(ICompanyService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<CompanyGetDto>> GetAll()
        {
            return await _service.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<CompanyGetDto> GetById(int id)
        {
            return await _service.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<CompanyGetDto> Create([FromBody] CompanyPostDto dto)
        {
            var result = await _service.CreateAsync(dto);
            return result.Data!;
        }

        [HttpPut("{id}")]
        public async Task<CompanyGetDto> Update(int id, [FromBody] CompanyPostDto dto)
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
