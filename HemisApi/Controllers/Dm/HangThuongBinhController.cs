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
    public class HangThuongBinhController : ControllerBase
    {
        private readonly DbHemisC500Context _context;

        public HangThuongBinhController(DbHemisC500Context context)
        {
            _context = context;
        }

        // GET: api/DmHangThuongBinh
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmHangThuongBinh>>> GetDmHangThuongBinhs()
        {
            return await _context.DmHangThuongBinhs.ToListAsync();
        }

        // GET: api/DmHangThuongBinh/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmHangThuongBinh>> GetDmHangThuongBinh(int id)
        {
            var dmHangThuongBinh = await _context.DmHangThuongBinhs.FindAsync(id);

            if (dmHangThuongBinh == null)
            {
                return NotFound();
            }

            return dmHangThuongBinh;
        }

        private bool DmHangThuongBinhExists(int id)
        {
            return _context.DmHangThuongBinhs.Any(e => e.IdHangThuongBinh == id);
        }
    }
}
