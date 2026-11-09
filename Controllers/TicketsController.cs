using HelloApi.Data;
using HelloApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HelloApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TicketsController : ControllerBase
{
    private readonly AppDbContext _db;

    public TicketsController(AppDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Ticket>>> GetAll()
        => Ok(await _db.Tickets.ToListAsync());

    [HttpGet("{id}")]
    public async Task<ActionResult<Ticket>> GetById(int id)
    {
        var ticket = await _db.Tickets.FindAsync(id);
        if (ticket is null) return NotFound();
        return Ok(ticket);
    }


    [HttpPost]
    public async Task<ActionResult<Ticket>> Create(Ticket ticket)
    {
        if (string.IsNullOrWhiteSpace(ticket.Title))
            return BadRequest("Title is required.");

        ticket.Id = 0;
        _db.Tickets.Add(ticket);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = ticket.Id }, ticket);
    }

    [HttpPut("{id}")]
public async Task<IActionResult> Update(int id, Ticket updated)
{
    var ticket = await _db.Tickets.FindAsync(id);
    if (ticket is null) return NotFound();

    if (string.IsNullOrWhiteSpace(updated.Title))
        return BadRequest("Title is required.");

    ticket.Title = updated.Title;
    ticket.Description = updated.Description;
    ticket.Status = updated.Status;

    await _db.SaveChangesAsync();
    return NoContent();
}

[HttpDelete("{id}")]
public async Task<IActionResult> Delete(int id)
{
    var ticket = await _db.Tickets.FindAsync(id);
    if (ticket is null) return NotFound();

    _db.Tickets.Remove(ticket);
    await _db.SaveChangesAsync();
    return NoContent();
}
}