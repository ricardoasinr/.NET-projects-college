using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAltura.Data;
using WebAltura.Models;

namespace WebAltura.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIClientesController : ControllerBase
    {
        public class Parametros
        {
            public int Inicial { get; set; }
            public int Final { get; set; }
        }
        public class Respuesta
        {
            public int aleatorio { get; set; }
        }
        
            public class RespuestaLetra
        {
            public char letraAleatoria { get; set; }
        }

        private readonly AlturaDbContext _context;

        public APIClientesController(AlturaDbContext context)
        {
            _context = context;
        }

        // GET: api/APIClientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlturaCliente>>> GetCliente()
        {
            return await _context.Cliente.ToListAsync();
        }

        // GET: api/APIClientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AlturaCliente>> GetAlturaCliente(int id)
        {
            var alturaCliente = await _context.Cliente.FindAsync(id);

            if (alturaCliente == null)
            {
                return NotFound();
            }

            return alturaCliente;
        }

        // PUT: api/APIClientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlturaCliente(int id, AlturaCliente alturaCliente)
        {
            if (id != alturaCliente.ClienteId)
            {
                return BadRequest();
            }

            _context.Entry(alturaCliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlturaClienteExists(id))
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

        // POST: api/APIClientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AlturaCliente>> PostAlturaCliente(AlturaCliente alturaCliente)
        {
            _context.Cliente.Add(alturaCliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAlturaCliente", new { id = alturaCliente.ClienteId }, alturaCliente);
        }

        // DELETE: api/APIClientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlturaCliente(int id)
        {
            var alturaCliente = await _context.Cliente.FindAsync(id);
            if (alturaCliente == null)
            {
                return NotFound();
            }

            _context.Cliente.Remove(alturaCliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlturaClienteExists(int id)
        {
            return _context.Cliente.Any(e => e.ClienteId == id);
        }

        [HttpGet]
        [Route("Random")]
        public Respuesta Aleatorio()
        {
            Respuesta respuesta = new Respuesta();
            Random numeroAleatorio = new Random();
            respuesta.aleatorio = numeroAleatorio.Next(0, 101);
            return respuesta;
        }

        [HttpPost]
        [Route("Randomconparametros")]
        public Respuesta AleatoriotConRago([FromBody] Parametros numeros)
        {

            Respuesta respuesta = new Respuesta();
            Random r = new Random();
            respuesta.aleatorio = (r.Next(numeros.Inicial, (numeros.Final + 1)));

            return respuesta;
        }

        [HttpGet]
        [Route("Randomletras")]
        public RespuestaLetra letra()
        {
            RespuestaLetra respuesta = new RespuestaLetra();
            Random r = new Random();
            int numero = r.Next(26);
            char letraGenerada = (char)(((int)'A') + numero);
            respuesta.letraAleatoria = letraGenerada;
            return respuesta;
        }


    }
}
