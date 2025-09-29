using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ComidasTipicasAPI.Data;
using ComidasTipicasAPI.Models;

namespace ComidasTipicasAPI.Controllers;

[ApiController]
[Route("api/crucenos")]
public class CruceñosController : ControllerBase
{
    private readonly AppDbContext _context;

    public CruceñosController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/crucenos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<SantaCruz>>> GetAll()
    {
        return await _context.SantaCruces.AsNoTracking().ToListAsync();
    }

    // GET: api/crucenos/5
    [HttpGet("{id:int}")]
    public async Task<ActionResult<SantaCruz>> GetById(int id)
    {
        var item = await _context.SantaCruces.FindAsync(id);
        if (item == null) return NotFound();
        return item;
    }

    // POST: api/crucenos
    [HttpPost]
    public async Task<ActionResult<SantaCruz>> Create(SantaCruz model)
    {
        _context.SantaCruces.Add(model);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = model.Id }, model);
    }

    // PUT: api/crucenos/5
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, SantaCruz model)
    {
        if (id != model.Id) return BadRequest();

        _context.Entry(model).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!Exists(id)) return NotFound();
            throw;
        }

        return NoContent();
    }

    // DELETE: api/crucenos/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var item = await _context.SantaCruces.FindAsync(id);
        if (item == null) return NotFound();

        _context.SantaCruces.Remove(item);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    private bool Exists(int id) => _context.SantaCruces.Any(e => e.Id == id);
}
