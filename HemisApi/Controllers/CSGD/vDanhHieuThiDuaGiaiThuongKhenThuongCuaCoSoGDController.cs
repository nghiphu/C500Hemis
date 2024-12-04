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
    public class vDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGDController : ControllerBase
    {
        private readonly DbHemisC500Context _context;

        public vDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGDController(DbHemisC500Context context)
        {
            _context = context;
        }

        // GET: api/VDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGD
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd>>> GetVDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGDs()
        {
            return await _context.VDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGds.ToListAsync();
        }

        // GET: api/VDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGD/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd>> GetVDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGD(int id)
        {
            var VDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGD = await _context.VDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGds.FindAsync(id);

            if (VDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGD == null)
            {
                return NotFound();
            }
            return VDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGD;
        }

        
    }
}
