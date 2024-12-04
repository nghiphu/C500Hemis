using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HemisApi.Models;

namespace HemisApi.Controllers.Dm
{
    [Route("api/dm/[controller]")]
    [ApiController]
    public class NganhKinhTeController : ControllerBase
    {
        private readonly DbHemisC500Context _context;

        public NganhKinhTeController(DbHemisC500Context context)
        {
            _context = context;
        }

        // GET: api/DmNganhKinhTe
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmNganhKinhTe>>> GetDmNganhKinhTes()
        {
            return await _context.DmNganhKinhTes.ToListAsync();
        }

        // GET: api/DmNganhKinhTe/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmNganhKinhTe>> GetDmNganhKinhTe(int id)
        {
            var dmNganhKinhTe = await _context.DmNganhKinhTes.FindAsync(id);

            if (dmNganhKinhTe == null)
            {
                return NotFound();
            }

            return dmNganhKinhTe;
        }

        private bool DmNganhKinhTeExists(int id)
        {
            return _context.DmNganhKinhTes.Any(e => e.IdNganhKinhTe == id);
        }
    }
}
