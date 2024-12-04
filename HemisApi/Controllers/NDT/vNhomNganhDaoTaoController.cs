using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HemisApi.Models;

namespace HemisApi.Controllers.NDT
{
    [Route("api/ndt/[controller]")]
    [ApiController]
    public class vNhomNganhDaoTaoController : ControllerBase
    {
        private readonly DbHemisC500Context _context;

        public vNhomNganhDaoTaoController(DbHemisC500Context context)
        {
            _context = context;
        }

        // GET: api/VNhomNganhDaoTao
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VNhomNganhDaoTao>>> GetVNhomNganhDaoTaos()
        {
            return await _context.VNhomNganhDaoTaos.ToListAsync();
        }

        // GET: api/VNhomNganhDaoTao/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VNhomNganhDaoTao>> GetVNhomNganhDaoTao(int id)
        {
            var VNhomNganhDaoTao = await _context.VNhomNganhDaoTaos.FindAsync(id);

            if (VNhomNganhDaoTao == null)
            {
                return NotFound();
            }

            return VNhomNganhDaoTao;
        }

    
    }
}
