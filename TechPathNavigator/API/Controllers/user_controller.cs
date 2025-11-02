using Microsoft.AspNetCore.Mvc;
using TechPathNavigator.DTOs;
using TechPathNavigator.DTOs.User;
using TechPathNavigator.Services;
<<<<<<< HEAD
=======
using TechPathNavigator.Common.Messages;
>>>>>>> osama

namespace TechPathNavigator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _service;

        public UserController(UserService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _service.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _service.GetByIdAsync(id);
<<<<<<< HEAD
            if (user == null) return NotFound();
=======
            if (user == null) return NotFound(new { message = ApiMessages.UserNotFound });
>>>>>>> osama
            return Ok(user);
        }

        [HttpGet("email/{email}")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            var user = await _service.GetByEmailAsync(email);
<<<<<<< HEAD
            if (user == null) return NotFound();
=======
            if (user == null) return NotFound(new { message = ApiMessages.UserNotFound });
>>>>>>> osama
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserPostDto dto)
        {
<<<<<<< HEAD
=======
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

>>>>>>> osama
            var created = await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.UserId }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UserUpdateDto dto)
        {
<<<<<<< HEAD
            var updated = await _service.UpdateAsync(id, dto);
            if (updated == null) return NotFound();
=======
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _service.UpdateAsync(id, dto);
            if (updated == null) return NotFound(new { message = ApiMessages.UserNotFound });
>>>>>>> osama
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.DeleteAsync(id);
<<<<<<< HEAD
            if (!success) return NotFound();
=======
            if (!success) return NotFound(new { message = ApiMessages.UserNotFound });
>>>>>>> osama
            return NoContent();
        }
    }
}
