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
    public class vNhomNghienCuuManhController : ControllerBase
    {
        private readonly DbHemisC500Context _context;

        public vNhomNghienCuuManhController(DbHemisC500Context context)
        {
            _context = context;
        }

        // GET: api/VNhomNghienCuuManh
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VNhomNghienCuuManh>>> GetVNhomNghienCuuManhs()
        {
            return await _context.VNhomNghienCuuManhs.ToListAsync();
        }

        // GET: api/VNhomNghienCuuManh/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VNhomNghienCuuManh>> GetVNhomNghienCuuManh(int id)
        {
            var VNhomNghienCuuManh = await _context.VNhomNghienCuuManhs.FindAsync(id);

            if (VNhomNghienCuuManh == null)
            {
                return NotFound();
            }

            return VNhomNghienCuuManh;
        }

    
    }
}
