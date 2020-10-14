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
    public class BicicletasController : ControllerBase
    {

        public readonly ApplicationDbContext context;

        public BicicletasController(ApplicationDbContext ctx)
        {
            this.context = ctx;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Bicicleta>> Get()
        {
            List<Bicicleta> ltsBicicletas = context.Bicicleta.ToList();
            //List<Bicicleta> ltsBicicletas = context.Bicicleta.Include(x => x.Persona).ToList();
            return ltsBicicletas;


        }

        [HttpGet("{id}", Name = "ObtenerBici")]
        public ActionResult<Bicicleta> Get(int id)
        {
            var bici = context.Bicicleta.FirstOrDefault( x => x.Id == id);
            if (bici == null)
            {
                return NotFound();
            }
            return bici;

        }

        [HttpPost]
        public ActionResult Post([FromBody] Bicicleta bici)
        {
            context.Bicicleta.Add(bici);
            context.SaveChanges();

            return new CreatedAtRouteResult("ObtenerBici", new { id = bici.Id }, bici);
        }


        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Bicicleta bici)
        {
            var mibici = context.Bicicleta.FirstOrDefault(x => x.Id == id);

            if (id != mibici.Id)
            {
                return BadRequest();
            }

            mibici.Modelo = bici.Modelo;
            mibici.Color = bici.Color;
            mibici.Latitude = bici.Latitude;
            mibici.Longitud = bici.Longitud;

            context.Entry(mibici).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Bicicleta> Delete(int id)
        {
            var mibici = context.Bicicleta.FirstOrDefault(x => x.Id == id);
            
            if (mibici == null)
            {
                return NotFound();
            }
            context.Bicicleta.Remove(mibici);
            context.SaveChanges();
            return mibici;
        }

    }
}
