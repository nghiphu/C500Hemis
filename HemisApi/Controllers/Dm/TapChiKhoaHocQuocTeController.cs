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
    public class TapChiKhoaHocQuocTeController : ControllerBase
    {
        private readonly DbHemisC500Context _context;

        public TapChiKhoaHocQuocTeController(DbHemisC500Context context)
        {
            _context = context;
        }

        // GET: api/DmTapChiKhoaHocQuocTe
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmTapChiKhoaHocQuocTe>>> GetDmTapChiKhoaHocQuocTes()
        {
            return await _context.DmTapChiKhoaHocQuocTes.ToListAsync();
        }

        // GET: api/DmTapChiKhoaHocQuocTe/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmTapChiKhoaHocQuocTe>> GetDmTapChiKhoaHocQuocTe(int id)
        {
            var dmTapChiKhoaHocQuocTe = await _context.DmTapChiKhoaHocQuocTes.FindAsync(id);

            if (dmTapChiKhoaHocQuocTe == null)
            {
                return NotFound();
            }

            return dmTapChiKhoaHocQuocTe;
        }

        private bool DmTapChiKhoaHocQuocTeExists(int id)
        {
            return _context.DmTapChiKhoaHocQuocTes.Any(e => e.IdTapChiKhoaHocQuocTe == id);
        }
    }
}
