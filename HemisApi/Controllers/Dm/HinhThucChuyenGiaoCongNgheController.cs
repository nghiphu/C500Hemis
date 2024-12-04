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
    public class HinhThucChuyenGiaoCongNgheController : ControllerBase
    {
        private readonly DbHemisC500Context _context;

        public HinhThucChuyenGiaoCongNgheController(DbHemisC500Context context)
        {
            _context = context;
        }

        // GET: api/DmHinhThucChuyenGiaoCongNghe
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmHinhThucChuyenGiaoCongNghe>>> GetDmHinhThucChuyenGiaoCongNghes()
        {
            return await _context.DmHinhThucChuyenGiaoCongNghes.ToListAsync();
        }

        // GET: api/DmHinhThucChuyenGiaoCongNghe/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmHinhThucChuyenGiaoCongNghe>> GetDmHinhThucChuyenGiaoCongNghe(int id)
        {
            var dmHinhThucChuyenGiaoCongNghe = await _context.DmHinhThucChuyenGiaoCongNghes.FindAsync(id);

            if (dmHinhThucChuyenGiaoCongNghe == null)
            {
                return NotFound();
            }

            return dmHinhThucChuyenGiaoCongNghe;
        }

        private bool DmHinhThucChuyenGiaoCongNgheExists(int id)
        {
            return _context.DmHinhThucChuyenGiaoCongNghes.Any(e => e.IdHinhThucChuyenGiaoCongNghe == id);
        }
    }
}
