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
    public class QuyetDinhTuChuController : ControllerBase
    {
        private readonly DbHemisC500Context _context;

        public QuyetDinhTuChuController(DbHemisC500Context context)
        {
            _context = context;
        }

        // GET: api/DmQuyetDinhTuChu
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmQuyetDinhTuChu>>> GetDmQuyetDinhTuChus()
        {
            return await _context.DmQuyetDinhTuChus.ToListAsync();
        }

        // GET: api/DmQuyetDinhTuChu/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmQuyetDinhTuChu>> GetDmQuyetDinhTuChu(int id)
        {
            var dmQuyetDinhTuChu = await _context.DmQuyetDinhTuChus.FindAsync(id);

            if (dmQuyetDinhTuChu == null)
            {
                return NotFound();
            }

            return dmQuyetDinhTuChu;
        }

        private bool DmQuyetDinhTuChuExists(int id)
        {
            return _context.DmQuyetDinhTuChus.Any(e => e.IdQuyetDinhTuChu == id);
        }
    }
}
