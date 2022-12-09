using Microsoft.EntityFrameworkCore;
using FullTecno.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullTecno.Data
{
    public class FullTecnoContext : DbContext
    {
        public FullTecnoContext(DbContextOptions<FullTecnoContext> options) : base(options)
        {

        }

        public DbSet<Audifonos> Audifonos { get; set; }
        public DbSet<Monitores> Monitores { get; set; }
        public DbSet<Mouses> Mouses { get; set; }
        public DbSet<Procesadores> Procesadores { get; set; }
        public DbSet<TarjetasGraficas> TarjetasGraficas { get; set; }



    }
}