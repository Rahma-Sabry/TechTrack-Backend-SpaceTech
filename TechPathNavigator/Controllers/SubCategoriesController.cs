using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechPathNavigator.Data;      // Namespace for ApplicationDbContext
using TechPathNavigator.Models;    // Namespace for your models
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TechPathNavigator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SubCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SubCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubCategory>>> GetSubCategories()
        {
            return await _context.SubCategories
                                 .Include(s => s.Category) // optional, if you want to include Category info
                                 .ToListAsync();
        }

        // GET: api/SubCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubCategory>> GetSubCategory(int id)
        {
            var subCategory = await _context.SubCategories
                                            .Include(s => s.Category)
                                            .FirstOrDefaultAsync(s => s.SubCategoryId == id);

            if (subCategory == null)
                return NotFound();

            return subCategory;
        }

        // POST: api/SubCategories
        [HttpPost]
        public async Task<ActionResult<SubCategory>> PostSubCategory(SubCategory subCategory)
        {
            _context.SubCategories.Add(subCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSubCategory), new { id = subCategory.SubCategoryId }, subCategory);
        }

        // PUT: api/SubCategories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubCategory(int id, SubCategory subCategory)
        {
            if (id != subCategory.SubCategoryId)
                return BadRequest();

            _context.Entry(subCategory).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/SubCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubCategory(int id)
        {
            var subCategory = await _context.SubCategories.FindAsync(id);
            if (subCategory == null)
                return NotFound();

            _context.SubCategories.Remove(subCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
