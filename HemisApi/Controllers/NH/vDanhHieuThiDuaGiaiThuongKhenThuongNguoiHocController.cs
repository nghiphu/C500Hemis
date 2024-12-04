using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HemisApi.Models;

namespace HemisApi.Controllers.NH
{
    [Route("api/nh/[controller]")]
    [ApiController]
    public class vDanhHieuThiDuaGiaiThuongKhenThuongNguoiHocController : ControllerBase
    {
        private readonly DbHemisC500Context _context;

        public vDanhHieuThiDuaGiaiThuongKhenThuongNguoiHocController(DbHemisC500Context context)
        {
            _context = context;
        }

        // GET: api/VDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc>>> GetVDanhHieuThiDuaGiaiThuongKhenThuongNguoiHocs()
        {
            return await _context.VDanhHieuThiDuaGiaiThuongKhenThuongNguoiHocs.ToListAsync();
        }

        // GET: api/VDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc>> GetVDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc(int id)
        {
            var VDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc = await _context.VDanhHieuThiDuaGiaiThuongKhenThuongNguoiHocs.FindAsync(id);

            if (VDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc == null)
            {
                return NotFound();
            }

            return VDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc;
        }

 
    }
}
