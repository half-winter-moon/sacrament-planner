using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sacramentplanner.Models;

namespace sacramentplanner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SacramentController : ControllerBase
    {
        private readonly SacramentPlannerContext _context;

        public SacramentController(SacramentPlannerContext context)
        {
            _context = context;
        }

        // GET: api/Sacrament
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SacramentPlan>>> GetSacramentPlans()
        {
          if (_context.SacramentPlans == null)
          {
              return NotFound();
          }
            return await _context.SacramentPlans
                .Include(t => t.Talks)
                .ToListAsync();
        }

        // GET: api/Sacrament/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SacramentPlan>> GetSacramentPlan(int id)
        {
          if (_context.SacramentPlans == null)
          {
              return NotFound();
          }
            var sacramentPlan = await _context.SacramentPlans
                .Include(t => t.Talks)
                .FirstOrDefaultAsync(s => s.SacramentPlanId == id);

            if (sacramentPlan == null)
            {
                return NotFound();
            }

            return sacramentPlan;
        }

        // PUT: api/Sacrament/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSacramentPlan(int id, SacramentPlan sacramentPlan)
        {
            if (id != sacramentPlan.SacramentPlanId)
            {
                return BadRequest();
            }

            _context.Entry(sacramentPlan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SacramentPlanExists(id))
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

        // POST: api/Sacrament
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SacramentPlan>> PostSacramentPlan(SacramentPlan sacramentPlan)
        {
          if (_context.SacramentPlans == null)
          {
              return Problem("Entity set 'SacramentPlannerContext.SacramentPlans'  is null.");
          }
            _context.SacramentPlans.Add(sacramentPlan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSacramentPlan", new { id = sacramentPlan.SacramentPlanId }, sacramentPlan);
        }

        // DELETE: api/Sacrament/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSacramentPlan(int id)
        {
            if (_context.SacramentPlans == null)
            {
                return NotFound();
            }
            var sacramentPlan = await _context.SacramentPlans.FindAsync(id);
            if (sacramentPlan == null)
            {
                return NotFound();
            }

            _context.SacramentPlans.Remove(sacramentPlan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SacramentPlanExists(int id)
        {
            return (_context.SacramentPlans?.Any(e => e.SacramentPlanId == id)).GetValueOrDefault();
        }
    }
}
