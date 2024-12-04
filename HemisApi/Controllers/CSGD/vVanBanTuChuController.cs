using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HemisApi.Models;

namespace HemisApi.Controllers.CSGD
{
    [Route("api/csgd/[controller]")]
    [ApiController]
    public class vVanBanTuChuController : ControllerBase
    {
        private readonly DbHemisC500Context _context;

        public vVanBanTuChuController(DbHemisC500Context context)
        {
            _context = context;
        }

        // GET: api/VVanBanTuChu
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VVanBanTuChu>>> GetVVanBanTuChus()
        {
            return await _context.VVanBanTuChus.ToListAsync();
        }

        // GET: api/VVanBanTuChu/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VVanBanTuChu>> GetVVanBanTuChu(int id)
        {
            var VVanBanTuChu = await _context.VVanBanTuChus.FindAsync(id);

            if (VVanBanTuChu == null)
            {
                return NotFound();
            }

            return VVanBanTuChu;
        }

        
       
    }
}
