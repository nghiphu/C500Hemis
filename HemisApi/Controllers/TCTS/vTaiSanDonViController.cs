using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HemisApi.Models;

namespace HemisApi.Controllers.TCTS
{
    [Route("api/tcts/[controller]")]
    [ApiController]
    public class vTaiSanDonViController : ControllerBase
    {
        private readonly DbHemisC500Context _context;

        public vTaiSanDonViController(DbHemisC500Context context)
        {
            _context = context;
        }

        // GET: api/VTaiSanDonVi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VTaiSanDonVi>>> GetVTaiSanDonVis()
        {
            return await _context.VTaiSanDonVis.ToListAsync();
        }

        // GET: api/VTaiSanDonVi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VTaiSanDonVi>> GetVTaiSanDonVi(int id)
        {
            var VTaiSanDonVi = await _context.VTaiSanDonVis.FindAsync(id);

            if (VTaiSanDonVi == null)
            {
                return NotFound();
            }

            return VTaiSanDonVi;
        }

    
    }
}
