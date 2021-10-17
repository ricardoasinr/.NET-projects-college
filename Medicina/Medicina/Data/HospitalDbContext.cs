using Medicina.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;


namespace Medicina.Data
{
    public class HospitalDbContext : DbContext
    {
        


         public DbSet<Hospital> Doctores { get; set; }

        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options) { }
    }
            
        

        
   
}
        
       

