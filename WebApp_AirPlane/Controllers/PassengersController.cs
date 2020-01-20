using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp_AirPlane.Models;

namespace WebApp_AirPlane.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public object Nome { get; private set; }

        public PassengersController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/Passengers
        [HttpPost]
        public async Task<IActionResult> InsertPassanger([FromBody] Passengers passengers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Passengers.Add(passengers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPassengers", new { id = passengers.IdPassageiro }, passengers);
        }

        // POST: api/PassengersAirplane
        [HttpPost]
        public async Task<IActionResult> InsertPassangerToAirplane([FromBody] Passengers passengers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Passengers.Add(passengers);

            await _context.SaveChangesAsync();

            var passengerID = await _context.Passengers
                    .Include(i => i.IdAviao)
                    .FirstOrDefaultAsync(i => i.IdAviao == passengers.IdAviao);

            return CreatedAtAction("GetPassengers", new { id = passengers.IdPassageiro }, passengerID);
        }

        // PUT: api/Passengers/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> ChangePassanger([FromRoute] int id, [FromBody] Passengers passengers)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != passengers.IdPassageiro)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(passengers.IdAviao).State = EntityState.Modified;
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PassengersExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // GET: api/Passengers
        [HttpGet("{id}")]
        public ActionResult ListAllPassangerByAirplane()
        {
            var result = from p in _context.Passengers
                                join a in _context.AirPlane on p.IdAviao equals a.IdAviao
                                select new
                                {
                                  p.Nome,
                                  p.Logradouro,
                                  p.Numero,
                                  p.Bairro,
                                  p.Municipio,
                                  p.Estado,
                                  p.Cep,
                                  p.Telefone,
                                };
            return Ok(result);
        }

        // GET: api/Passengers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPassengers([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var passengers = await _context.Passengers.FindAsync(id);

            if (passengers == null)
            {
                return NotFound();
            }

            return Ok(passengers);
        }

        

        
        private bool PassengersExists(int id)
        {
            return _context.Passengers.Any(e => e.IdPassageiro == id);
        }
    }
}