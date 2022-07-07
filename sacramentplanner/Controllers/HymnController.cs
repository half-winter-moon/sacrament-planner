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
    public class HymnController : ControllerBase
    {
        private readonly SacramentPlannerContext _context;

        public HymnController(SacramentPlannerContext context)
        {
            _context = context;
        }

        // GET: api/Hymn
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hymn>>> GetHymns()
        {
          if (_context.Hymns == null)
          {
              return NotFound();
          }
            return await _context.Hymns.ToListAsync();
        }

        // GET: api/Hymn/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hymn>> GetHymn(int id)
        {
          if (_context.Hymns == null)
          {
              return NotFound();
          }
            var hymn = await _context.Hymns.FindAsync(id);

            if (hymn == null)
            {
                return NotFound();
            }

            return hymn;
        }

        private bool HymnExists(int id)
        {
            return (_context.Hymns?.Any(e => e.HymnId == id)).GetValueOrDefault();
        }
    }
}
