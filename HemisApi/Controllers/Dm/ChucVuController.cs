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
    public class ChucVuController : ControllerBase
    {
        private readonly DbHemisC500Context _context;

        public ChucVuController(DbHemisC500Context context)
        {
            _context = context;
        }

        // GET: api/DmChucVu
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmChucVu>>> GetDmChucVus()
        {
            return await _context.DmChucVus.ToListAsync();
        }

        // GET: api/DmChucVu/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmChucVu>> GetDmChucVu(int id)
        {
            var dmChucVu = await _context.DmChucVus.FindAsync(id);

            if (dmChucVu == null)
            {
                return NotFound();
            }

            return dmChucVu;
        }

        private bool DmChucVuExists(int id)
        {
            return _context.DmChucVus.Any(e => e.IdChucVu == id);
        }
    }
}
