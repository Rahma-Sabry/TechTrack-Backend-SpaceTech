using Microsoft.AspNetCore.Mvc;
using TechPathNavigator.DTOs;
using TechPathNavigator.Service.Track;

namespace TechPathNavigator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrackController : ControllerBase
    {
        private readonly ITrackService _service;

        public TrackController(ITrackService service)
        {
            _service = service;
        }

        // GET: api/Track
        [HttpGet]
        public Task<IEnumerable<TrackGetDto>> GetAll() =>
            _service.GetAllTracksAsync();

        // GET: api/Track/{id}
        [HttpGet("{id}")]
        public Task<TrackGetDto> GetById(int id) =>
            _service.GetTrackByIdAsync(id);

        // POST: api/Track
        [HttpPost]
        public Task<TrackGetDto> Create([FromBody] TrackPostDto trackDto) =>
            _service.CreateTrackAsync(trackDto);

        // PUT: api/Track/{id}
        [HttpPut("{id}")]
        public Task<TrackGetDto> Update(int id, [FromBody] TrackPostDto trackDto) =>
            _service.UpdateTrackAsync(id, trackDto);

        // DELETE: api/Track/{id}
        [HttpDelete("{id}")]
        public Task<bool> Delete(int id) =>
            _service.DeleteTrackAsync(id);
    }
}
