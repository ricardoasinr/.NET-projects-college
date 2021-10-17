using ApiFuturo.Data;
using ApiFuturo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiFuturo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MagicController : ControllerBase
    {
        private readonly AppDbContext _context;



        public MagicController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<Pronostico>> GetFuturos()
        {
            var list = await _context.Futuros.ToListAsync();

            var max = list.Count;
            int index = new Random().Next(0, max);
            var pronostico = list[index];

            if (pronostico == null)
            {
                return NoContent();
            }

            return pronostico;
        }
    }
}