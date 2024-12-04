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
    public class PhanLoaiDoiTuongController : ControllerBase
    {
        private readonly DbHemisC500Context _context;

        public PhanLoaiDoiTuongController(DbHemisC500Context context)
        {
            _context = context;
        }

        // GET: api/DmPhanLoaiDoiTuong
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmPhanLoaiDoiTuong>>> GetDmPhanLoaiDoiTuongs()
        {
            return await _context.DmPhanLoaiDoiTuongs.ToListAsync();
        }

        // GET: api/DmPhanLoaiDoiTuong/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmPhanLoaiDoiTuong>> GetDmPhanLoaiDoiTuong(int id)
        {
            var dmPhanLoaiDoiTuong = await _context.DmPhanLoaiDoiTuongs.FindAsync(id);

            if (dmPhanLoaiDoiTuong == null)
            {
                return NotFound();
            }

            return dmPhanLoaiDoiTuong;
        }

        private bool DmPhanLoaiDoiTuongExists(int id)
        {
            return _context.DmPhanLoaiDoiTuongs.Any(e => e.IdPhanLoaiDoiTuong == id);
        }
    }
}
