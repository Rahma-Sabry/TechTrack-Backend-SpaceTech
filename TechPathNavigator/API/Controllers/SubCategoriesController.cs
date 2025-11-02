using Microsoft.AspNetCore.Mvc;
using TechPathNavigator.DTOs;
using TechPathNavigator.Services;
using TechPathNavigator.Common.Messages;

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
        public async Task<ActionResult<IEnumerable<SubCategoryGetDto>>> GetAll()
        {
            var subCategories = await _service.GetAllAsync();
            return Ok(subCategories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SubCategoryGetDto>> GetById(int id)
        {
            var subCategory = await _service.GetByIdAsync(id);
            if (subCategory == null)
                return NotFound(new { message = ApiMessages.SubCategoryNotFound });
            return Ok(subCategory);
        }

        [HttpGet("ByCategory/{categoryId}")]
        public async Task<ActionResult<IEnumerable<SubCategoryGetDto>>> GetByCategoryId(int categoryId)
        {
            var subCategories = await _service.GetByCategoryIdAsync(categoryId);
            return Ok(subCategories);
        }

        [HttpPost]
        public async Task<ActionResult<SubCategoryGetDto>> Create([FromBody] SubCategoryPostDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdSubCategory = await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById),
                new { id = createdSubCategory.SubCategoryId },
                createdSubCategory);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SubCategoryGetDto>> Update(int id, [FromBody] SubCategoryPostDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedSubCategory = await _service.UpdateAsync(id, dto);
            if (updatedSubCategory == null)
                return NotFound(new { message = ApiMessages.SubCategoryNotFound });
            return Ok(updatedSubCategory);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            if (!result)
                return NotFound(new { message = ApiMessages.SubCategoryNotFound });
            return NoContent();
        }
    }
}
