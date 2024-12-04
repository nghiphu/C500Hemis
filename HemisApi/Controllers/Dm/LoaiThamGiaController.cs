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
    public class LoaiThamGiaController : ControllerBase
    {
        private readonly DbHemisC500Context _context;

        public LoaiThamGiaController(DbHemisC500Context context)
        {
            _context = context;
        }

        // GET: api/DmLoaiThamGium
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmLoaiThamGium>>> GetDmLoaiThamGiums()
        {
            return await _context.DmLoaiThamGia.ToListAsync();
        }

        // GET: api/DmLoaiThamGium/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmLoaiThamGium>> GetDmLoaiThamGium(int id)
        {
            var DmLoaiThamGium = await _context.DmLoaiThamGia.FindAsync(id);

            if (DmLoaiThamGium == null)
            {
                return NotFound();
            }

            return DmLoaiThamGium;
        }

        private bool DmLoaiThamGiumExists(int id)
        {
            return _context.DmLoaiThamGia.Any(e => e.IdLoaiThamGia == id);
        }
    }
}
