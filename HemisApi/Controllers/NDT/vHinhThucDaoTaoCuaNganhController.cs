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
    public class vHinhThucDaoTaoCuaNganhController : ControllerBase
    {
        private readonly DbHemisC500Context _context;

        public vHinhThucDaoTaoCuaNganhController(DbHemisC500Context context)
        {
            _context = context;
        }

        // GET: api/VHinhThucDaoTaoCuaNganh
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VHinhThucDaoTaoCuaNganh>>> GetVHinhThucDaoTaoCuaNganhs()
        {
            return await _context.VHinhThucDaoTaoCuaNganhs.ToListAsync();
        }

        // GET: api/VHinhThucDaoTaoCuaNganh/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VHinhThucDaoTaoCuaNganh>> GetVHinhThucDaoTaoCuaNganh(int id)
        {
            var VHinhThucDaoTaoCuaNganh = await _context.VHinhThucDaoTaoCuaNganhs.FindAsync(id);

            if (VHinhThucDaoTaoCuaNganh == null)
            {
                return NotFound();
            }

            return VHinhThucDaoTaoCuaNganh;
        }

    }
}
