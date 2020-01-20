using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp_AirPlane.Models;

namespace WebApp_AirPlane.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirplanesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AirplanesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Airplanes
        [HttpGet]
        public ActionResult<IEnumerable<Airplane>> GetAllAirPlane()
        {
            return _context.AirPlane.ToList();
        }

        // GET: api/Airplanes/1
        [HttpGet("{id}")]
        public async Task<IActionResult> FindAirplane([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var airplane = await _context.AirPlane.FindAsync(id);

            if (airplane == null)
            {
                return NotFound();
            }

            return Ok(airplane);
        }

        // POST: api/Airplanes
        [HttpPost]
        public async Task<IActionResult> InsertAirplane([FromBody] Airplane airplane)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.AirPlane.Add(airplane);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAllAirPlane", new { id = airplane.IdAviao }, airplane);
        }

        
    }
}