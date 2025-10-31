using Microsoft.AspNetCore.Mvc;
using TechPathNavigator.DTOs;
using TechPathNavigator.Services;
using FluentValidation;

namespace TechPathNavigator.Controllers
{
    /// <summary>
    /// Category management endpoints
    /// Handles CRUD operations with validation
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        /// <summary>
        /// Retrieves all categories
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CategoryGetDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<CategoryGetDto>>> GetAll()
        {
            var categories = await _service.GetAllCategoriesAsync();
            return Ok(categories);
        }

        /// <summary>
        /// Retrieves a category by ID
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CategoryGetDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CategoryGetDto>> GetById(int id)
        {
            var category = await _service.GetCategoryByIdAsync(id);
            if (category == null)
                return NotFound(new { message = $"Category with ID {id} not found" });

            return Ok(category);
        }

        /// <summary>
        /// Creates a new category
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(CategoryGetDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CategoryGetDto>> Create([FromBody] CategoryPostDto dto)
        {
            try
            {
                var created = await _service.CreateCategoryAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = created.CategoryId }, created);
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { errors = ex.Errors.Select(e => e.ErrorMessage) });
            }
        }

        /// <summary>
        /// Updates an existing category
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(CategoryGetDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CategoryGetDto>> Update(int id, [FromBody] CategoryPostDto dto)
        {
            try
            {
                var updated = await _service.UpdateCategoryAsync(id, dto);
                if (updated == null)
                    return NotFound(new { message = $"Category with ID {id} not found" });

                return Ok(updated);
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { errors = ex.Errors.Select(e => e.ErrorMessage) });
            }
        }

        /// <summary>
        /// Deletes a category
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteCategoryAsync(id);
            if (!result)
                return NotFound(new { message = $"Category with ID {id} not found" });

            return NoContent();
        }
    }
}
