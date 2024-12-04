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
    public class LoaiHinhCoSoDaoTaoController : ControllerBase
    {
        private readonly DbHemisC500Context _context;

        public LoaiHinhCoSoDaoTaoController(DbHemisC500Context context)
        {
            _context = context;
        }

        // GET: api/DmLoaiHinhCoSoDaoTao
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmLoaiHinhCoSoDaoTao>>> GetDmLoaiHinhCoSoDaoTaos()
        {
            return await _context.DmLoaiHinhCoSoDaoTaos.ToListAsync();
        }

        // GET: api/DmLoaiHinhCoSoDaoTao/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmLoaiHinhCoSoDaoTao>> GetDmLoaiHinhCoSoDaoTao(int id)
        {
            var dmLoaiHinhCoSoDaoTao = await _context.DmLoaiHinhCoSoDaoTaos.FindAsync(id);

            if (dmLoaiHinhCoSoDaoTao == null)
            {
                return NotFound();
            }

            return dmLoaiHinhCoSoDaoTao;
        }

        private bool DmLoaiHinhCoSoDaoTaoExists(int id)
        {
            return _context.DmLoaiHinhCoSoDaoTaos.Any(e => e.IdLoaiHinhCoSoDaoTao == id);
        }
    }
}
