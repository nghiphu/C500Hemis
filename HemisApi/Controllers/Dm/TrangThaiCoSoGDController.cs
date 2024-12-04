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
    public class TrangThaiCoSoGdController : ControllerBase
    {
        private readonly DbHemisC500Context _context;

        public TrangThaiCoSoGdController(DbHemisC500Context context)
        {
            _context = context;
        }

        // GET: api/DmTrangThaiCoSoGd
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmTrangThaiCoSoGd>>> GetDmTrangThaiCoSoGds()
        {
            return await _context.DmTrangThaiCoSoGds.ToListAsync();
        }

        // GET: api/DmTrangThaiCoSoGd/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmTrangThaiCoSoGd>> GetDmTrangThaiCoSoGd(int id)
        {
            var dmTrangThaiCoSoGd = await _context.DmTrangThaiCoSoGds.FindAsync(id);

            if (dmTrangThaiCoSoGd == null)
            {
                return NotFound();
            }

            return dmTrangThaiCoSoGd;
        }

        private bool DmTrangThaiCoSoGdExists(int id)
        {
            return _context.DmTrangThaiCoSoGds.Any(e => e.IdTrangThaiCoSoGd == id);
        }
    }
}
