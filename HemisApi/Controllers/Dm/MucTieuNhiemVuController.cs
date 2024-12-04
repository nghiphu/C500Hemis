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
    public class MucTieuNhiemVuController : ControllerBase
    {
        private readonly DbHemisC500Context _context;

        public MucTieuNhiemVuController(DbHemisC500Context context)
        {
            _context = context;
        }

        // GET: api/DmMucTieuNhiemVu
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmMucTieuNhiemVu>>> GetDmMucTieuNhiemVus()
        {
            return await _context.DmMucTieuNhiemVus.ToListAsync();
        }

        // GET: api/DmMucTieuNhiemVu/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmMucTieuNhiemVu>> GetDmMucTieuNhiemVu(int id)
        {
            var dmMucTieuNhiemVu = await _context.DmMucTieuNhiemVus.FindAsync(id);

            if (dmMucTieuNhiemVu == null)
            {
                return NotFound();
            }

            return dmMucTieuNhiemVu;
        }

        private bool DmMucTieuNhiemVuExists(int id)
        {
            return _context.DmMucTieuNhiemVus.Any(e => e.IdMucTieuNhiemVu == id);
        }
    }
}
