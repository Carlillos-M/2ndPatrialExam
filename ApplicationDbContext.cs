using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SecondPartialExam.Entities;

namespace SecondPartialExam
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Juguete> Juguetes { get; set; }
        public DbSet<Marca> Marcas { get; set; }
    }
}