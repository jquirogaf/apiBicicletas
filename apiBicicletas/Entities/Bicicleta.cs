using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiBicicletas.Entities
{
    public class Bicicleta
    {
        public int Id { get; set; }

        public int Modelo { get; set; }

        public string Color { get; set; }

        public string Latitude { get; set; }

        public string Longitud { get; set; }

        public int PersonaId { get; set; }
        public Persona Persona { get; set; }

    }
}
