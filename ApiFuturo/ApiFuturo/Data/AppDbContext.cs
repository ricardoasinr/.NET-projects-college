﻿using ApiFuturo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiFuturo.Data
{
    public class AppDbContext: DbContext
    {
        public DbSet <Pronostico> Futuros { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}
