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
    public class SinhVienNamController : ControllerBase
    {
        private readonly DbHemisC500Context _context;

        public SinhVienNamController(DbHemisC500Context context)
        {
            _context = context;
        }

        // GET: api/DmSinhVienNam
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmSinhVienNam>>> GetDmSinhVienNams()
        {
            return await _context.DmSinhVienNams.ToListAsync();
        }

        // GET: api/DmSinhVienNam/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmSinhVienNam>> GetDmSinhVienNam(int id)
        {
            var dmSinhVienNam = await _context.DmSinhVienNams.FindAsync(id);

            if (dmSinhVienNam == null)
            {
                return NotFound();
            }

            return dmSinhVienNam;
        }

        private bool DmSinhVienNamExists(int id)
        {
            return _context.DmSinhVienNams.Any(e => e.IdSinhVienNam == id);
        }
    }
}
