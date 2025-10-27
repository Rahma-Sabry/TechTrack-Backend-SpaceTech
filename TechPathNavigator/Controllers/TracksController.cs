using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechPathNavigator.Data;      // For ApplicationDbContext
using TechPathNavigator.Models;    // For Track, SubCategory models
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TechPathNavigator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TracksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TracksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Tracks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Track>>> GetTracks()
        {
            // Include related SubCategory info if available
            return await _context.Tracks
                                 .Include(t => t.SubCategory)
                                 .ToListAsync();
        }

        // GET: api/Tracks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Track>> GetTrack(int id)
        {
            var track = await _context.Tracks
                                      .Include(t => t.SubCategory)
                                      .FirstOrDefaultAsync(t => t.TrackId == id);

            if (track == null)
                return NotFound();

            return track;
        }

        // POST: api/Tracks
        [HttpPost]
        public async Task<ActionResult<Track>> PostTrack(Track track)
        {
            _context.Tracks.Add(track);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTrack), new { id = track.TrackId }, track);
        }

        // PUT: api/Tracks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrack(int id, Track track)
        {
            if (id != track.TrackId)
                return BadRequest();

            _context.Entry(track).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrackExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/Tracks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrack(int id)
        {
            var track = await _context.Tracks.FindAsync(id);
            if (track == null)
                return NotFound();

            _context.Tracks.Remove(track);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrackExists(int id)
        {
            return _context.Tracks.Any(e => e.TrackId == id);
        }
    }
}
