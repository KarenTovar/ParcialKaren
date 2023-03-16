using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParcialBackend.Models;

namespace ParcialBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmaciumsController : ControllerBase
    {
        private readonly DrogueriaContext _context;

        public FarmaciumsController(DrogueriaContext context)
        {
            _context = context;
        }

        // GET: api/Farmaciums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Farmacium>>> GetFarmacia()
        {
          if (_context.Farmacia == null)
          {
              return NotFound();
          }
            return await _context.Farmacia.ToListAsync();
        }

        // GET: api/Farmaciums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Farmacium>> GetFarmacium(int id)
        {
          if (_context.Farmacia == null)
          {
              return NotFound();
          }
            var farmacium = await _context.Farmacia.FindAsync(id);

            if (farmacium == null)
            {
                return NotFound();
            }

            return farmacium;
        }

        // PUT: api/Farmaciums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFarmacium(int id, Farmacium farmacium)
        {
            if (id != farmacium.IdFarmacia)
            {
                return BadRequest();
            }

            _context.Entry(farmacium).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FarmaciumExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Farmaciums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Farmacium>> PostFarmacium(Farmacium farmacium)
        {
          if (_context.Farmacia == null)
          {
              return Problem("Entity set 'DrogueriaContext.Farmacia'  is null.");
          }
            _context.Farmacia.Add(farmacium);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FarmaciumExists(farmacium.IdFarmacia))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFarmacium", new { id = farmacium.IdFarmacia }, farmacium);
        }

        // DELETE: api/Farmaciums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFarmacium(int id)
        {
            if (_context.Farmacia == null)
            {
                return NotFound();
            }
            var farmacium = await _context.Farmacia.FindAsync(id);
            if (farmacium == null)
            {
                return NotFound();
            }

            _context.Farmacia.Remove(farmacium);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FarmaciumExists(int id)
        {
            return (_context.Farmacia?.Any(e => e.IdFarmacia == id)).GetValueOrDefault();
        }
    }
}
