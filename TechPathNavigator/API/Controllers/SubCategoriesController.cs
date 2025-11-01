using Microsoft.AspNetCore.Mvc;
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

        // GET: api/SubCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubCategoryGetDto>>> GetAll()
        {
            try
            {
                var subCategories = await _service.GetAllAsync();
                return Ok(subCategories);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An error occurred while retrieving subcategories",
                    error = ex.Message
                });
            }
        }

        // GET: api/SubCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubCategoryGetDto>> GetById(int id)
        {
            try
            {
                var subCategory = await _service.GetByIdAsync(id);

                if (subCategory == null)
                    return NotFound(new { message = $"SubCategory with ID {id} not found" });

                return Ok(subCategory);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An error occurred while retrieving the subcategory",
                    error = ex.Message
                });
            }
        }

        // GET: api/SubCategories/ByCategory/3
        [HttpGet("ByCategory/{categoryId}")]
        public async Task<ActionResult<IEnumerable<SubCategoryGetDto>>> GetByCategoryId(int categoryId)
        {
            try
            {
                var subCategories = await _service.GetByCategoryIdAsync(categoryId);
                return Ok(subCategories);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An error occurred while retrieving subcategories for the category",
                    error = ex.Message
                });
            }
        }

        // POST: api/SubCategories
        [HttpPost]
        public async Task<ActionResult<SubCategoryGetDto>> Create([FromBody] SubCategoryPostDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var createdSubCategory = await _service.AddAsync(dto);
                return CreatedAtAction(nameof(GetById),
                    new { id = createdSubCategory.SubCategoryId },
                    createdSubCategory);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An error occurred while creating the subcategory",
                    error = ex.Message
                });
            }
        }

        // PUT: api/SubCategories/5
        [HttpPut("{id}")]
        public async Task<ActionResult<SubCategoryGetDto>> Update(int id, [FromBody] SubCategoryPostDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var updatedSubCategory = await _service.UpdateAsync(id, dto);

                if (updatedSubCategory == null)
                    return NotFound(new { message = $"SubCategory with ID {id} not found" });

                return Ok(updatedSubCategory);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An error occurred while updating the subcategory",
                    error = ex.Message
                });
            }
        }

        // DELETE: api/SubCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _service.DeleteAsync(id);

                if (!result)
                    return NotFound(new { message = $"SubCategory with ID {id} not found" });

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An error occurred while deleting the subcategory",
                    error = ex.Message
                });
            }
        }
    }
}
