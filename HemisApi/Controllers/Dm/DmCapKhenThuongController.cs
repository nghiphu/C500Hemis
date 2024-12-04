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
    public class DmCapKhenThuongController : ControllerBase
    {
        private readonly DbHemisC500Context _context;

        public DmCapKhenThuongController(DbHemisC500Context context)
        {
            _context = context;
        }

        // GET: api/DmCapKhenThuong
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmCapKhenThuong>>> GetDmCapKhenThuongs()
        {
            return await _context.DmCapKhenThuongs.ToListAsync();
        }

        // GET: api/DmCapKhenThuong/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmCapKhenThuong>> GetDmCapKhenThuong(int id)
        {
            var dmCapKhenThuong = await _context.DmCapKhenThuongs.FindAsync(id);

            if (dmCapKhenThuong == null)
            {
                return NotFound();
            }

            return dmCapKhenThuong;
        }

        private bool DmCapKhenThuongExists(int id)
        {
            return _context.DmCapKhenThuongs.Any(e => e.IdCapKhenThuong == id);
        }
    }
}
