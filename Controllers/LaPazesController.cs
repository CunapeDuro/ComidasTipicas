using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ComidasTipicasAPI.Models;
using ComidasTipicasAPI.Data;

namespace ComidasTipicasAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LaPazController : ControllerBase
{
    private readonly AppDbContext _context;

    public LaPazController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/lapaz
    [HttpGet]
    public async Task<ActionResult<IEnumerable<LaPaz>>> Get(string? nombre, string? restaurante)
    {
        var query = _context.LaPazes.AsQueryable();

        if (!string.IsNullOrWhiteSpace(nombre))
        {
            query = query.Where(l => l.Nombre.Contains(nombre));
        }

        if (!string.IsNullOrWhiteSpace(restaurante))
        {
            query = query.Where(l => l.Restaurante.Contains(restaurante));
        }

        return Ok(await query.ToListAsync());
    }

    // GET: api/lapaz/5
    [HttpGet("{id:int}")]
    public async Task<ActionResult<LaPaz>> GetById(int id)
    {
        var lapaz = await _context.LaPazes.FindAsync(id);
        if (lapaz == null) return NotFound();
        return Ok(lapaz);
    }

    // POST: api/lapaz
    [HttpPost]
    public async Task<ActionResult<LaPaz>> Create(LaPaz lapaz)
    {
        _context.LaPazes.Add(lapaz);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = lapaz.Id }, lapaz);
    }

    // PUT: api/lapaz/5
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Replace(int id, LaPaz lapaz)
    {
        if (id != lapaz.Id)
        {
            return BadRequest("El ID de la URL no coincide con el del objeto enviado.");
        }

        var existing = await _context.LaPazes.FindAsync(id);
        if (existing == null) return NotFound();

        existing.Nombre = lapaz.Nombre;
        existing.IngredientePrincipal = lapaz.IngredientePrincipal;
        existing.Restaurante = lapaz.Restaurante;
        existing.Precio = lapaz.Precio;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/lapaz/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var existing = await _context.LaPazes.FindAsync(id);
        if (existing == null) return NotFound();

        _context.LaPazes.Remove(existing);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
