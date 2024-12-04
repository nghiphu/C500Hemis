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
    public class HeSoLuongController : ControllerBase
    {
        private readonly DbHemisC500Context _context;

        public HeSoLuongController(DbHemisC500Context context)
        {
            _context = context;
        }

        // GET: api/DmHeSoLuong
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmHeSoLuong>>> GetDmHeSoLuongs()
        {
            return await _context.DmHeSoLuongs.ToListAsync();
        }

        // GET: api/DmHeSoLuong/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmHeSoLuong>> GetDmHeSoLuong(int id)
        {
            var dmHeSoLuong = await _context.DmHeSoLuongs.FindAsync(id);

            if (dmHeSoLuong == null)
            {
                return NotFound();
            }

            return dmHeSoLuong;
        }

        private bool DmHeSoLuongExists(int id)
        {
            return _context.DmHeSoLuongs.Any(e => e.IdHeSoLuong == id);
        }
    }
}
