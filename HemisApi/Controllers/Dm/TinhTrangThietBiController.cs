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
    public class TinhTrangThietBiController : ControllerBase
    {
        private readonly DbHemisC500Context _context;

        public TinhTrangThietBiController(DbHemisC500Context context)
        {
            _context = context;
        }

        // GET: api/DmTinhTrangThietBi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmTinhTrangThietBi>>> GetDmTinhTrangThietBis()
        {
            return await _context.DmTinhTrangThietBis.ToListAsync();
        }

        // GET: api/DmTinhTrangThietBi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmTinhTrangThietBi>> GetDmTinhTrangThietBi(int id)
        {
            var dmTinhTrangThietBi = await _context.DmTinhTrangThietBis.FindAsync(id);

            if (dmTinhTrangThietBi == null)
            {
                return NotFound();
            }

            return dmTinhTrangThietBi;
        }

        private bool DmTinhTrangThietBiExists(int id)
        {
            return _context.DmTinhTrangThietBis.Any(e => e.IdTinhTrangThietBi == id);
        }
    }
}
