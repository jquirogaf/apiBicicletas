using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiBicicletas.Entities
{
    public class Persona
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Lastname { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public List<Bicicleta> Bicicletas { get; set; }
    }
}
