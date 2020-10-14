using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using apiBicicletas.Context;
using apiBicicletas.Entities;
using Microsoft.EntityFrameworkCore;


namespace apiBicicletas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {

        public readonly ApplicationDbContext context;

        public PersonaController(ApplicationDbContext ctx)
        {
            this.context = ctx;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Persona>> Get()
        {
            return context.Persona.ToList();

        }

        [HttpGet("{id}", Name = "ObtenerPersona")]
        public ActionResult<Persona> Get(int id)
        {
            var perso = context.Persona.FirstOrDefault(x => x.Id == id);
            if (perso == null)
            {
                return NotFound();
            }
            return perso;

        }

        [HttpPost]
        public ActionResult<IEnumerable<Persona>> Post([FromBody] Persona perso)
        {
            context.Persona.Add(perso);
            context.SaveChanges();

            return new CreatedAtRouteResult("ObtenerPersona", new Persona { Id = perso.Id }, perso);
        }


        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Persona perso)
        {
            var miperso = context.Persona.FirstOrDefault(x => x.Id == id);

            if (id != miperso.Id)
            {
                return BadRequest();
            }

            miperso.Name = perso.Name;
            miperso.Lastname = perso.Lastname;
            miperso.Address = perso.Address;
            miperso.Phone = perso.Phone;


            context.Entry(miperso).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Persona> Delete(int id)
        {
            var miperso = context.Persona.FirstOrDefault(x => x.Id == id);

            if (miperso == null)
            {
                return NotFound();
            }
            context.Persona.Remove(miperso);
            context.SaveChanges();
            return miperso;
        }

    }
}
