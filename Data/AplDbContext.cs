using Microsoft.EntityFrameworkCore;
using Peliculas.CRUD.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peliculas.CRUD.EF.Data
{
    public class AplDbContext : DbContext
    {
        public AplDbContext(DbContextOptions<AplDbContext> options)
        : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        //entities
        public DbSet<Film> Films { get; set; }
    }
}
