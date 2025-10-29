using Microsoft.AspNetCore.Mvc;
using TechPathNavigator.DTOs;

[HttpPost]
public async Task<IActionResult> Create(TrackPostDto dto)
{
    try
    {
        var created = await _service.AddAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.TrackId }, created);
    }
    catch (ArgumentException ex)
    {
        return BadRequest(ex.Message);
    }
}
