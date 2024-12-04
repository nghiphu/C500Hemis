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
    public class LoaiHocBongController : ControllerBase
    {
        private readonly DbHemisC500Context _context;

        public LoaiHocBongController(DbHemisC500Context context)
        {
            _context = context;
        }

        // GET: api/DmLoaiHocBong
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmLoaiHocBong>>> GetDmLoaiHocBongs()
        {
            return await _context.DmLoaiHocBongs.ToListAsync();
        }

        // GET: api/DmLoaiHocBong/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmLoaiHocBong>> GetDmLoaiHocBong(int id)
        {
            var dmLoaiHocBong = await _context.DmLoaiHocBongs.FindAsync(id);

            if (dmLoaiHocBong == null)
            {
                return NotFound();
            }

            return dmLoaiHocBong;
        }

        private bool DmLoaiHocBongExists(int id)
        {
            return _context.DmLoaiHocBongs.Any(e => e.IdLoaiHocBong == id);
        }
    }
}
