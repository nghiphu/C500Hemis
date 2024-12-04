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
    public class LoaiHocVienController : ControllerBase
    {
        private readonly DbHemisC500Context _context;

        public LoaiHocVienController(DbHemisC500Context context)
        {
            _context = context;
        }

        // GET: api/DmLoaiHocVien
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmLoaiHocVien>>> GetDmLoaiHocViens()
        {
            return await _context.DmLoaiHocViens.ToListAsync();
        }

        // GET: api/DmLoaiHocVien/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmLoaiHocVien>> GetDmLoaiHocVien(int id)
        {
            var dmLoaiHocVien = await _context.DmLoaiHocViens.FindAsync(id);

            if (dmLoaiHocVien == null)
            {
                return NotFound();
            }

            return dmLoaiHocVien;
        }

        private bool DmLoaiHocVienExists(int id)
        {
            return _context.DmLoaiHocViens.Any(e => e.IdLoaiHocVien == id);
        }
    }
}
