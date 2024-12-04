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
    public class VaiTroThamGiaController : ControllerBase
    {
        private readonly DbHemisC500Context _context;

        public VaiTroThamGiaController(DbHemisC500Context context)
        {
            _context = context;
        }

        // GET: api/DmVaiTroThamGia
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmVaiTroThamGium>>> GetDmVaiTroThamGias()
        {
            return await _context.DmVaiTroThamGia.ToListAsync();
        }

        // GET: api/DmVaiTroThamGia/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmVaiTroThamGium>> GetDmVaiTroThamGia(int id)
        {
            var dmVaiTroThamGia = await _context.DmVaiTroThamGia.FindAsync(id);

            if (dmVaiTroThamGia == null)
            {
                return NotFound();
            }

            return dmVaiTroThamGia;
        }

        private bool DmVaiTroThamGiaExists(int id)
        {
            return _context.DmVaiTroThamGia.Any(e => e.IdVaiTroThamGia == id);
        }
    }
}
