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
    public class HinhThucDaoTaoController : ControllerBase
    {
        private readonly DbHemisC500Context _context;

        public HinhThucDaoTaoController(DbHemisC500Context context)
        {
            _context = context;
        }

        // GET: api/DmHinhThucDaoTao
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmHinhThucDaoTao>>> GetDmHinhThucDaoTaos()
        {
            return await _context.DmHinhThucDaoTaos.ToListAsync();
        }

        // GET: api/DmHinhThucDaoTao/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmHinhThucDaoTao>> GetDmHinhThucDaoTao(int id)
        {
            var dmHinhThucDaoTao = await _context.DmHinhThucDaoTaos.FindAsync(id);

            if (dmHinhThucDaoTao == null)
            {
                return NotFound();
            }

            return dmHinhThucDaoTao;
        }

        private bool DmHinhThucDaoTaoExists(int id)
        {
            return _context.DmHinhThucDaoTaos.Any(e => e.IdHinhThucDaoTao == id);
        }
    }
}
