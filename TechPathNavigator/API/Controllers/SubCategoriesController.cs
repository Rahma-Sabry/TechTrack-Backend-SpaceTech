using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechPathNavigator.DTOs;
using TechPathNavigator.Services;

namespace TechPathNavigator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubCategoriesController : ControllerBase
    {
        private readonly ISubCategoryService _service;

        public SubCategoriesController(ISubCategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<SubCategoryGetDto>> GetAll()
        {
            return await _service.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<SubCategoryGetDto> GetById(int id)
        {
            return await _service.GetByIdAsync(id);
        }

        [HttpGet("ByCategory/{categoryId}")]
        public async Task<IEnumerable<SubCategoryGetDto>> GetByCategoryId(int categoryId)
        {
            return await _service.GetByCategoryIdAsync(categoryId);
        }

        [HttpPost]
        public async Task<SubCategoryGetDto> Create([FromBody] SubCategoryPostDto dto)
        {
            return await _service.AddAsync(dto);
        }

        [HttpPut("{id}")]
        public async Task<SubCategoryGetDto> Update(int id, [FromBody] SubCategoryPostDto dto)
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
