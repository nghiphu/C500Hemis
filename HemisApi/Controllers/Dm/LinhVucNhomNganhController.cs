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
    public class LinhVucNhomNganhController : ControllerBase
    {
        private readonly DbHemisC500Context _context;

        public LinhVucNhomNganhController(DbHemisC500Context context)
        {
            _context = context;
        }

        // GET: api/DmLinhVucNhomNganh
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmLinhVucNhomNganh>>> GetDmLinhVucNhomNganhs()
        {
            return await _context.DmLinhVucNhomNganhs.ToListAsync();
        }

        // GET: api/DmLinhVucNhomNganh/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmLinhVucNhomNganh>> GetDmLinhVucNhomNganh(int id)
        {
            var dmLinhVucNhomNganh = await _context.DmLinhVucNhomNganhs.FindAsync(id);

            if (dmLinhVucNhomNganh == null)
            {
                return NotFound();
            }

            return dmLinhVucNhomNganh;
        }

        private bool DmLinhVucNhomNganhExists(int id)
        {
            return _context.DmLinhVucNhomNganhs.Any(e => e.IdLinhVucNhomNganh == id);
        }
    }
}
