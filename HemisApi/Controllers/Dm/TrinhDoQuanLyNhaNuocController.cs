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
    public class TrinhDoQuanLyNhaNuocController : ControllerBase
    {
        private readonly DbHemisC500Context _context;

        public TrinhDoQuanLyNhaNuocController(DbHemisC500Context context)
        {
            _context = context;
        }

        // GET: api/DmTrinhDoQuanLyNhaNuoc
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmTrinhDoQuanLyNhaNuoc>>> GetDmTrinhDoQuanLyNhaNuocs()
        {
            return await _context.DmTrinhDoQuanLyNhaNuocs.ToListAsync();
        }

        // GET: api/DmTrinhDoQuanLyNhaNuoc/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmTrinhDoQuanLyNhaNuoc>> GetDmTrinhDoQuanLyNhaNuoc(int id)
        {
            var dmTrinhDoQuanLyNhaNuoc = await _context.DmTrinhDoQuanLyNhaNuocs.FindAsync(id);

            if (dmTrinhDoQuanLyNhaNuoc == null)
            {
                return NotFound();
            }

            return dmTrinhDoQuanLyNhaNuoc;
        }

        private bool DmTrinhDoQuanLyNhaNuocExists(int id)
        {
            return _context.DmTrinhDoQuanLyNhaNuocs.Any(e => e.IdTrinhDoQuanLyNhaNuoc == id);
        }
    }
}
