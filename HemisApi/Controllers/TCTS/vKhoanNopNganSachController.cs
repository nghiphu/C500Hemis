using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HemisApi.Models;

namespace HemisApi.Controllers.TCTS
{
    [Route("api/tcts/[controller]")]
    [ApiController]
    public class vKhoanNopNganSachController : ControllerBase
    {
        private readonly DbHemisC500Context _context;

        public vKhoanNopNganSachController(DbHemisC500Context context)
        {
            _context = context;
        }

        // GET: api/VKhoanNopNganSach
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VKhoanNopNganSach>>> GetVKhoanNopNganSachs()
        {
            return await _context.VKhoanNopNganSaches.ToListAsync();
        }

        // GET: api/VKhoanNopNganSach/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VKhoanNopNganSach>> GetVKhoanNopNganSach(int id)
        {
            var VKhoanNopNganSach = await _context.VKhoanNopNganSaches.FindAsync(id);

            if (VKhoanNopNganSach == null)
            {
                return NotFound();
            }

            return VKhoanNopNganSach;
        }
    }
}
