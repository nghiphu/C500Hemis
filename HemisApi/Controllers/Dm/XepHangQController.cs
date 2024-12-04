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
    public class XepHangQController : ControllerBase
    {
        private readonly DbHemisC500Context _context;

        public XepHangQController(DbHemisC500Context context)
        {
            _context = context;
        }

        // GET: api/DmXepHangQ
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmXepHangQ>>> GetDmXepHangQs()
        {
            return await _context.DmXepHangQs.ToListAsync();
        }

        // GET: api/DmXepHangQ/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmXepHangQ>> GetDmXepHangQ(int id)
        {
            var dmXepHangQ = await _context.DmXepHangQs.FindAsync(id);

            if (dmXepHangQ == null)
            {
                return NotFound();
            }

            return dmXepHangQ;
        }

        private bool DmXepHangQExists(int id)
        {
            return _context.DmXepHangQs.Any(e => e.IdXepHangQ == id);
        }
    }
}
