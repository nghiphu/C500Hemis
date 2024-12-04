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
    public class LinhVucDaoTaoController : ControllerBase
    {
        private readonly DbHemisC500Context _context;

        public LinhVucDaoTaoController(DbHemisC500Context context)
        {
            _context = context;
        }

        // GET: api/DmLinhVucDaoTao
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmLinhVucDaoTao>>> GetDmLinhVucDaoTaos()
        {
            return await _context.DmLinhVucDaoTaos.ToListAsync();
        }

        // GET: api/DmLinhVucDaoTao/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmLinhVucDaoTao>> GetDmLinhVucDaoTao(int id)
        {
            var dmLinhVucDaoTao = await _context.DmLinhVucDaoTaos.FindAsync(id);

            if (dmLinhVucDaoTao == null)
            {
                return NotFound();
            }

            return dmLinhVucDaoTao;
        }

        private bool DmLinhVucDaoTaoExists(int id)
        {
            return _context.DmLinhVucDaoTaos.Any(e => e.IdLinhVucDaoTao == id);
        }
    }
}
