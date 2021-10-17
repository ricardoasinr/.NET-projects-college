using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiFuturo.Data;
using ApiFuturo.Models;

namespace ApiFuturo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuturosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FuturosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Futuros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pronostico>>> GetFuturos()
        {
            return await _context.Futuros.ToListAsync();
        }

        // GET: api/Futuros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pronostico>> GetPronostico(string id)
        {
            var pronostico = await _context.Futuros.FindAsync(id);

            if (pronostico == null)
            {
                return NotFound();
            }

            return pronostico;
        }

        // PUT: api/Futuros/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPronostico(string id, Pronostico pronostico)
        {
            if (id != pronostico.FuturId)
            {
                return BadRequest();
            }

            _context.Entry(pronostico).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PronosticoExists(id))
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

        // POST: api/Futuros
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pronostico>> PostPronostico(Pronostico pronostico)
        {
            _context.Futuros.Add(pronostico);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PronosticoExists(pronostico.FuturId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPronostico", new { id = pronostico.FuturId }, pronostico);
        }

        // DELETE: api/Futuros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePronostico(string id)
        {
            var pronostico = await _context.Futuros.FindAsync(id);
            if (pronostico == null)
            {
                return NotFound();
            }

            _context.Futuros.Remove(pronostico);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PronosticoExists(string id)
        {
            return _context.Futuros.Any(e => e.FuturId == id);
        }
    }
}
