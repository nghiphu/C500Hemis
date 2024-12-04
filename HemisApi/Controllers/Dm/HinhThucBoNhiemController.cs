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
    public class HinhThucBoNhiemController : ControllerBase
    {
        private readonly DbHemisC500Context _context;

        public HinhThucBoNhiemController(DbHemisC500Context context)
        {
            _context = context;
        }

        // GET: api/DmHinhThucBoNhiem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmHinhThucBoNhiem>>> GetDmHinhThucBoNhiems()
        {
            return await _context.DmHinhThucBoNhiems.ToListAsync();
        }

        // GET: api/DmHinhThucBoNhiem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmHinhThucBoNhiem>> GetDmHinhThucBoNhiem(int id)
        {
            var dmHinhThucBoNhiem = await _context.DmHinhThucBoNhiems.FindAsync(id);

            if (dmHinhThucBoNhiem == null)
            {
                return NotFound();
            }

            return dmHinhThucBoNhiem;
        }

        private bool DmHinhThucBoNhiemExists(int id)
        {
            return _context.DmHinhThucBoNhiems.Any(e => e.IdHinhThucBoNhiem == id);
        }
    }
}
