using Microsoft.AspNetCore.Mvc;
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

        // GET: api/category
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryGetDto>>> GetAll()
        {
            try
            {
                var categories = await _service.GetAllCategoriesAsync();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving categories", error = ex.Message });
            }
        }

        // GET: api/category/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryGetDto>> GetById(int id)
        {
            try
            {
                var category = await _service.GetCategoryByIdAsync(id);

                if (category == null)
                    return NotFound(new { message = $"Category with ID {id} not found" });

                return Ok(category);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving the category", error = ex.Message });
            }
        }

        // POST: api/category
        [HttpPost]
        public async Task<ActionResult<CategoryGetDto>> Create([FromBody] CategoryPostDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var createdCategory = await _service.CreateCategoryAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = createdCategory.CategoryId }, createdCategory);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while creating the category", error = ex.Message });
            }
        }

        // PUT: api/category/5
        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryGetDto>> Update(int id, [FromBody] CategoryPostDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var updatedCategory = await _service.UpdateCategoryAsync(id, dto);

                if (updatedCategory == null)
                    return NotFound(new { message = $"Category with ID {id} not found" });

                return Ok(updatedCategory);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while updating the category", error = ex.Message });
            }
        }

        // DELETE: api/category/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _service.DeleteCategoryAsync(id);

                if (!result)
                    return NotFound(new { message = $"Category with ID {id} not found" });

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while deleting the category", error = ex.Message });
            }
        }
    }
}