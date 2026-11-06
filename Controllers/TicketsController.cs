using HelloApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace HelloApi.Controllers;
[ApiController]
[Route("api/[controller]")]
public class TicketsController : ControllerBase
{
    private static readonly List<Ticket> Tickets =
    [
        new Ticket { Id = 1, Title = "Login Error on MobileApp", Status = "Open" },
        new Ticket { Id = 2, Title = "Slow response on orders API", Status = "In Progress" }   
    ];
[HttpGet]
public ActionResult<IEnumerable<Ticket>> GetAll() => Ok(Tickets);
    [HttpGet("{id}")]
    public ActionResult<Ticket> GetById(int id)
    {
        var ticket = Tickets.FirstOrDefault(t => t.Id == id);
        if (ticket == null)
            return NotFound();
        return Ok(ticket);
    }

    [HttpPost]
    public ActionResult<Ticket> Create(Ticket ticket)
    {
        if (string.IsNullOrEmpty(ticket.Title))
        return BadRequest("Title is required.");

        ticket.Id = Tickets.Max(t => t.Id) + 1; 
        Tickets.Add(ticket);
        return CreatedAtAction(nameof(GetById), new { id = ticket.Id }, ticket);
        
    }

}   