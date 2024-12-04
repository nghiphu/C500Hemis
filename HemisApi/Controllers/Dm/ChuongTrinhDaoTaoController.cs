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
    public class ChuongTrinhDaoTaoController : ControllerBase
    {
        private readonly DbHemisC500Context _context;

        public ChuongTrinhDaoTaoController(DbHemisC500Context context)
        {
            _context = context;
        }

        // GET: api/DmChuongTrinhDaoTao
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmChuongTrinhDaoTao>>> GetDmChuongTrinhDaoTaos()
        {
            return await _context.DmChuongTrinhDaoTaos.ToListAsync();
        }

        // GET: api/DmChuongTrinhDaoTao/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmChuongTrinhDaoTao>> GetDmChuongTrinhDaoTao(int id)
        {
            var dmChuongTrinhDaoTao = await _context.DmChuongTrinhDaoTaos.FindAsync(id);

            if (dmChuongTrinhDaoTao == null)
            {
                return NotFound();
            }

            return dmChuongTrinhDaoTao;
        }

        private bool DmChuongTrinhDaoTaoExists(int id)
        {
            return _context.DmChuongTrinhDaoTaos.Any(e => e.IdChuongTrinhDaoTao == id);
        }
    }
}
