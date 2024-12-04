using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HemisApi.Models;

namespace HemisApi.Controllers.KHCN
{
    [Route("api/khcn/[controller]")]
    [ApiController]
    public class vSachDaXuatBanController : ControllerBase
    {
        private readonly DbHemisC500Context _context;

        public vSachDaXuatBanController(DbHemisC500Context context)
        {
            _context = context;
        }

        // GET: api/VSachDaXuatBan
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VSachDaXuatBan>>> GetVSachDaXuatBans()
        {
            return await _context.VSachDaXuatBans.ToListAsync();
        }

        // GET: api/VSachDaXuatBan/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VSachDaXuatBan>> GetVSachDaXuatBan(int id)
        {
            var VSachDaXuatBan = await _context.VSachDaXuatBans.FindAsync(id);

            if (VSachDaXuatBan == null)
            {
                return NotFound();
            }

            return VSachDaXuatBan;
        }

    }
}
