using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HemisApi.Models;

namespace HemisApi.Controllers.CTDT
{
    [Route("api/ctdt/[controller]")]
    [ApiController]
    public class vChuongTrinhDaoTaoController : ControllerBase
    {
        private readonly DbHemisC500Context _context;

        public vChuongTrinhDaoTaoController(DbHemisC500Context context)
        {
            _context = context;
        }

        // GET: api/VChuongTrinhDaoTao
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VChuongTrinhDaoTao>>> GetVChuongTrinhDaoTaos()
        {
            return await _context.VChuongTrinhDaoTaos.ToListAsync();
        }

        // GET: api/VChuongTrinhDaoTao/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VChuongTrinhDaoTao>> GetVChuongTrinhDaoTao(int id)
        {
            var VChuongTrinhDaoTao = await _context.VChuongTrinhDaoTaos.FindAsync(id);

            if (VChuongTrinhDaoTao == null)
            {
                return NotFound();
            }

            return VChuongTrinhDaoTao;
        }

    }
}
