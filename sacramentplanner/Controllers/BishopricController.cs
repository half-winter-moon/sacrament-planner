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
    public class BishopricController : ControllerBase
    {
        private readonly SacramentPlannerContext _context;

        public BishopricController(SacramentPlannerContext context)
        {
            _context = context;
        }

        // GET: api/Bishopric
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bishopric>>> GetBishoprics()
        {
          if (_context.Bishoprics == null)
          {
              return NotFound();
          }
            return await _context.Bishoprics.ToListAsync();
        }

        // GET: api/Bishopric/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bishopric>> GetBishopric(int id)
        {
          if (_context.Bishoprics == null)
          {
              return NotFound();
          }
            var bishopric = await _context.Bishoprics.FindAsync(id);

            if (bishopric == null)
            {
                return NotFound();
            }

            return bishopric;
        }

        private bool BishopricExists(int id)
        {
            return (_context.Bishoprics?.Any(e => e.BishopricId == id)).GetValueOrDefault();
        }
    }
}
