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
    public class vChiTietThuChiController : ControllerBase
    {
        private readonly DbHemisC500Context _context;

        public vChiTietThuChiController(DbHemisC500Context context)
        {
            _context = context;
        }

        // GET: api/VChiTietThuChi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VChiTietThuChi>>> GetVChiTietThuChis()
        {
            return await _context.VChiTietThuChis.ToListAsync();
        }

        // GET: api/VChiTietThuChi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VChiTietThuChi>> GetVChiTietThuChi(int id)
        {
            var VChiTietThuChi = await _context.VChiTietThuChis.FindAsync(id);

            if (VChiTietThuChi == null)
            {
                return NotFound();
            }

            return VChiTietThuChi;
        }

 
    }
}
