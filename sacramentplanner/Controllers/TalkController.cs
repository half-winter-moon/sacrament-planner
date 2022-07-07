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
    public class TalkController : ControllerBase
    {
        private readonly SacramentPlannerContext _context;

        public TalkController(SacramentPlannerContext context)
        {
            _context = context;
        }

        // GET: api/Talk
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Talk>>> GetTalks()
        {
          if (_context.Talks == null)
          {
              return NotFound();
          }
            return await _context.Talks.ToListAsync();
        }

        // GET: api/Talk/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Talk>> GetTalk(int id)
        {
          if (_context.Talks == null)
          {
              return NotFound();
          }
            var talk = await _context.Talks.FindAsync(id);

            if (talk == null)
            {
                return NotFound();
            }

            return talk;
        }

        // POST: api/Talk
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Talk>> PostTalk(Talk talk)
        {
          if (_context.Talks == null)
          {
              return Problem("Entity set 'SacramentPlannerContext.Talks'  is null.");
          }
            _context.Talks.Add(talk);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTalk", new { id = talk.TalkId }, talk);
        }
        private bool TalkExists(int id)
        {
            return (_context.Talks?.Any(e => e.TalkId == id)).GetValueOrDefault();
        }
    }
}
