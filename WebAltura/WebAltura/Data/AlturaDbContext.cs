using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAltura.Models;

namespace WebAltura.Data
{
    public class AlturaDbContext: DbContext
    {

        public DbSet <AlturaCliente> Cliente { get; set; }
        public AlturaDbContext(DbContextOptions<AlturaDbContext>options): base(options)
        {

        }
    }
}
