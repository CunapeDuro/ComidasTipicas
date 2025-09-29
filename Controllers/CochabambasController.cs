using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ComidasTipicasAPI.Models;
using ComidasTipicasAPI.Data;

namespace ComidasTipicasAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CochabambasController : ControllerBase
{
    private readonly AppDbContext _context;

    public CochabambasController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/Cochabambas
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Cochabamba>>> GetCochabambas()
    {
        return await _context.Cochabambas.ToListAsync();
    }

    // GET: api/Cochabambas/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Cochabamba>> GetCochabamba(int id)
    {
        var cochabamba = await _context.Cochabambas.FindAsync(id);

        if (cochabamba == null)
        {
            return NotFound();
        }

        return cochabamba;
    }

    // POST: api/Cochabambas
    [HttpPost]
    public async Task<ActionResult<Cochabamba>> PostCochabamba(Cochabamba cochabamba)
    {
        _context.Cochabambas.Add(cochabamba);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetCochabamba), new { id = cochabamba.Id }, cochabamba);
    }

    // PUT: api/Cochabambas/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCochabamba(int id, Cochabamba cochabamba)
    {
        if (id != cochabamba.Id)
        {
            return BadRequest();
        }

        _context.Entry(cochabamba).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CochabambaExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // DELETE: api/Cochabambas/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCochabamba(int id)
    {
        var cochabamba = await _context.Cochabambas.FindAsync(id);
        if (cochabamba == null)
        {
            return NotFound();
        }

        _context.Cochabambas.Remove(cochabamba);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool CochabambaExists(int id)
    {
        return _context.Cochabambas.Any(e => e.Id == id);
    }
}
