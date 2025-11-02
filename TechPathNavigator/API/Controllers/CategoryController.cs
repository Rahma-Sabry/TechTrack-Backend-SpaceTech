using Microsoft.AspNetCore.Mvc;
using TechPathNavigator.DTOs;
using TechPathNavigator.Services;
using TechPathNavigator.Common.Messages;

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

        // GET: api/category
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryGetDto>>> GetAll()
        {
            var categories = await _service.GetAllCategoriesAsync();
            return Ok(categories);
        }

        // GET: api/category/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryGetDto>> GetById(int id)
        {
            var category = await _service.GetCategoryByIdAsync(id);
            if (category == null)
                return NotFound(new { message = ApiMessages.CategoryNotFound });
            return Ok(category);
        }

        // POST: api/category
        [HttpPost]
        public async Task<ActionResult<CategoryGetDto>> Create([FromBody] CategoryPostDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdCategory = await _service.CreateCategoryAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = createdCategory.CategoryId }, createdCategory);
        }

        // PUT: api/category/5
        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryGetDto>> Update(int id, [FromBody] CategoryPostDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedCategory = await _service.UpdateCategoryAsync(id, dto);
            if (updatedCategory == null)
                return NotFound(new { message = ApiMessages.CategoryNotFound });
            return Ok(updatedCategory);
        }

        // DELETE: api/category/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteCategoryAsync(id);
            if (!result)
                return NotFound(new { message = ApiMessages.CategoryNotFound });
            return NoContent();
        }
    }
}
