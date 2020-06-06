using Microsoft.EntityFrameworkCore;
using PrimerParcialEjemplo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PrimerParcialEjemplo.DAL
{
    public class Contexto : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = Data\Persona.db");
        }

        public DbSet<Persona> Personas { get; set; }
    }
}
