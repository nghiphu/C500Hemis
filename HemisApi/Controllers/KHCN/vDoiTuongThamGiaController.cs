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
    public class vDoiTuongThamGiaController : ControllerBase
    {
        private readonly DbHemisC500Context _context;

        public vDoiTuongThamGiaController(DbHemisC500Context context)
        {
            _context = context;
        }

        // GET: api/VDoiTuongThamGia
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VDoiTuongThamGium>>> GetVDoiTuongThamGias()
        {
            return await _context.VDoiTuongThamGia.ToListAsync();
        }

        // GET: api/VDoiTuongThamGia/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VDoiTuongThamGium>> GetVDoiTuongThamGia(int id)
        {
            var VDoiTuongThamGia = await _context.VDoiTuongThamGia.FindAsync(id);

            if (VDoiTuongThamGia == null)
            {
                return NotFound();
            }

            return VDoiTuongThamGia;
        }

      
    }
}
