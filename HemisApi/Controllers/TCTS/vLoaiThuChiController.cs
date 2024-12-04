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
    public class vLoaiThuChiController : ControllerBase
    {
        private readonly DbHemisC500Context _context;

        public vLoaiThuChiController(DbHemisC500Context context)
        {
            _context = context;
        }

        // GET: api/VLoaiThuChi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VLoaiThuChi>>> GetVLoaiThuChis()
        {
            return await _context.VLoaiThuChis.ToListAsync();
        }

        // GET: api/VLoaiThuChi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VLoaiThuChi>> GetVLoaiThuChi(int id)
        {
            var VLoaiThuChi = await _context.VLoaiThuChis.FindAsync(id);

            if (VLoaiThuChi == null)
            {
                return NotFound();
            }

            return VLoaiThuChi;
        }

    }
}
