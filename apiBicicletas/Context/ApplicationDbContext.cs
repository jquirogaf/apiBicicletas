using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiBicicletas.Entities;
using Microsoft.EntityFrameworkCore;


namespace apiBicicletas.Context
{
    public class ApplicationDbContext: DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { 
        
        
        }

        public DbSet<Bicicleta> Bicicleta { get; set;}

        public DbSet<Persona> Persona { get; set; }


    }
}
