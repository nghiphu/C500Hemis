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
    public class TrinhDoDaoTaoController : ControllerBase
    {
        private readonly DbHemisC500Context _context;

        public TrinhDoDaoTaoController(DbHemisC500Context context)
        {
            _context = context;
        }

        // GET: api/DmTrinhDoDaoTao
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmTrinhDoDaoTao>>> GetDmTrinhDoDaoTaos()
        {
            return await _context.DmTrinhDoDaoTaos.ToListAsync();
        }

        // GET: api/DmTrinhDoDaoTao/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmTrinhDoDaoTao>> GetDmTrinhDoDaoTao(int id)
        {
            var dmTrinhDoDaoTao = await _context.DmTrinhDoDaoTaos.FindAsync(id);

            if (dmTrinhDoDaoTao == null)
            {
                return NotFound();
            }

            return dmTrinhDoDaoTao;
        }

        private bool DmTrinhDoDaoTaoExists(int id)
        {
            return _context.DmTrinhDoDaoTaos.Any(e => e.IdTrinhDoDaoTao == id);
        }
    }
}
