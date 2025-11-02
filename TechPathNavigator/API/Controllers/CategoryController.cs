using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechPathNavigator.DTOs;
using TechPathNavigator.Services;

namespace TechPathNavigator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoryGetDto>> GetAll()
        {
            return await _service.GetAllCategoriesAsync();
        }

        [HttpGet("{id}")]
        public async Task<CategoryGetDto> GetById(int id)
        {
            return await _service.GetCategoryByIdAsync(id);
        }

        [HttpPost]
        public async Task<CategoryGetDto> Create([FromBody] CategoryPostDto dto)
        {
            return await _service.CreateCategoryAsync(dto);
        }

        [HttpPut("{id}")]
        public async Task<CategoryGetDto> Update(int id, [FromBody] CategoryPostDto dto)
        {
            return await _service.UpdateCategoryAsync(id, dto);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _service.DeleteCategoryAsync(id);
        }
    }
}
