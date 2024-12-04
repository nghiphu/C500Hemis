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
    public class LinhVucNghienCuuController : ControllerBase
    {
        private readonly DbHemisC500Context _context;

        public LinhVucNghienCuuController(DbHemisC500Context context)
        {
            _context = context;
        }

        // GET: api/DmLinhVucNghienCuu
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmLinhVucNghienCuu>>> GetDmLinhVucNghienCuus()
        {
            return await _context.DmLinhVucNghienCuus.ToListAsync();
        }

        // GET: api/DmLinhVucNghienCuu/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmLinhVucNghienCuu>> GetDmLinhVucNghienCuu(int id)
        {
            var dmLinhVucNghienCuu = await _context.DmLinhVucNghienCuus.FindAsync(id);

            if (dmLinhVucNghienCuu == null)
            {
                return NotFound();
            }

            return dmLinhVucNghienCuu;
        }

        private bool DmLinhVucNghienCuuExists(int id)
        {
            return _context.DmLinhVucNghienCuus.Any(e => e.IdLinhVucNghienCuu == id);
        }
    }
}
