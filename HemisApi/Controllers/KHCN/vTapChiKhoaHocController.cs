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
    public class vTapChiKhoaHocController : ControllerBase
    {
        private readonly DbHemisC500Context _context;

        public vTapChiKhoaHocController(DbHemisC500Context context)
        {
            _context = context;
        }

        // GET: api/VTapChiKhoaHoc
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VTapChiKhoaHoc>>> GetVTapChiKhoaHocs()
        {
            return await _context.VTapChiKhoaHocs.ToListAsync();
        }

        // GET: api/VTapChiKhoaHoc/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VTapChiKhoaHoc>> GetVTapChiKhoaHoc(int id)
        {
            var VTapChiKhoaHoc = await _context.VTapChiKhoaHocs.FindAsync(id);

            if (VTapChiKhoaHoc == null)
            {
                return NotFound();
            }

            return VTapChiKhoaHoc;
        }

    }
}
