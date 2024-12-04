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
    public class KhoiNganhLinhVucDaoTaoController : ControllerBase
    {
        private readonly DbHemisC500Context _context;

        public KhoiNganhLinhVucDaoTaoController(DbHemisC500Context context)
        {
            _context = context;
        }

        // GET: api/DmKhoiNganhLinhVucDaoTao
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmKhoiNganhLinhVucDaoTao>>> GetDmKhoiNganhLinhVucDaoTaos()
        {
            return await _context.DmKhoiNganhLinhVucDaoTaos.ToListAsync();
        }

        // GET: api/DmKhoiNganhLinhVucDaoTao/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmKhoiNganhLinhVucDaoTao>> GetDmKhoiNganhLinhVucDaoTao(int id)
        {
            var dmKhoiNganhLinhVucDaoTao = await _context.DmKhoiNganhLinhVucDaoTaos.FindAsync(id);

            if (dmKhoiNganhLinhVucDaoTao == null)
            {
                return NotFound();
            }

            return dmKhoiNganhLinhVucDaoTao;
        }

        private bool DmKhoiNganhLinhVucDaoTaoExists(int id)
        {
            return _context.DmKhoiNganhLinhVucDaoTaos.Any(e => e.IdKhoiNganh == id);
        }
    }
}
