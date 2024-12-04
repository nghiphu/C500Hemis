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
    public class vToChucKiemDinhController : ControllerBase
    {
        private readonly DbHemisC500Context _context;

        public vToChucKiemDinhController(DbHemisC500Context context)
        {
            _context = context;
        }

        // GET: api/VToChucKiemDinh
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VToChucKiemDinh>>> GetVToChucKiemDinhs()
        {
            return await _context.VToChucKiemDinhs.ToListAsync();
        }

        // GET: api/VToChucKiemDinh/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VToChucKiemDinh>> GetVToChucKiemDinh(int id)
        {
            var VToChucKiemDinh = await _context.VToChucKiemDinhs.FindAsync(id);

            if (VToChucKiemDinh == null)
            {
                return NotFound();
            }

            return VToChucKiemDinh;
        }

    }
}
