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
    public class LoaiDanhHieuThiDuaGiaiThuongKhenThuongController : ControllerBase
    {
        private readonly DbHemisC500Context _context;

        public LoaiDanhHieuThiDuaGiaiThuongKhenThuongController(DbHemisC500Context context)
        {
            _context = context;
        }

        // GET: api/DmLoaiDanhHieuThiDuaGiaiThuongKhenThuong
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmLoaiDanhHieuThiDuaGiaiThuongKhenThuong>>> GetDmLoaiDanhHieuThiDuaGiaiThuongKhenThuongs()
        {
            return await _context.DmLoaiDanhHieuThiDuaGiaiThuongKhenThuongs.ToListAsync();
        }

        // GET: api/DmLoaiDanhHieuThiDuaGiaiThuongKhenThuong/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmLoaiDanhHieuThiDuaGiaiThuongKhenThuong>> GetDmLoaiDanhHieuThiDuaGiaiThuongKhenThuong(int id)
        {
            var dmLoaiDanhHieuThiDuaGiaiThuongKhenThuong = await _context.DmLoaiDanhHieuThiDuaGiaiThuongKhenThuongs.FindAsync(id);

            if (dmLoaiDanhHieuThiDuaGiaiThuongKhenThuong == null)
            {
                return NotFound();
            }

            return dmLoaiDanhHieuThiDuaGiaiThuongKhenThuong;
        }

        private bool DmLoaiDanhHieuThiDuaGiaiThuongKhenThuongExists(int id)
        {
            return _context.DmLoaiDanhHieuThiDuaGiaiThuongKhenThuongs.Any(e => e.IdLoaiDanhHieuThiDuaGiaiThuongKhenThuong == id);
        }
    }
}
