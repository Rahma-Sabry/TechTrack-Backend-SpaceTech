using Microsoft.AspNetCore.Mvc;
using TechPathNavigator.Data;
using TechPathNavigator.Models;

namespace TechPathNavigator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnologyController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TechnologyController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var techs = _context.Technologies.ToList();
            return Ok(techs);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var tech = _context.Technologies.Find(id);
            if (tech == null) return NotFound();
            return Ok(tech);
        }

        [HttpPost]
        public IActionResult Create(Technology tech)
        {
            _context.Technologies.Add(tech);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = tech.TechnologyId }, tech);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Technology updated)
        {
            var tech = _context.Technologies.Find(id);
            if (tech == null) return NotFound();

            tech.TechnologyName = updated.TechnologyName;
            tech.Description = updated.Description;
            _context.SaveChanges();

            return Ok(tech);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var tech = _context.Technologies.Find(id);
            if (tech == null) return NotFound();

            _context.Technologies.Remove(tech);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
