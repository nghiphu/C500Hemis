using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HemisApi.Models;

namespace HemisApi.Controllers.HTQT
{
    [Route("api/htqt/[controller]")]
    [ApiController]
    public class vThoaThuanHopTacQuocTeController : ControllerBase
    {
        private readonly DbHemisC500Context _context;

        public vThoaThuanHopTacQuocTeController(DbHemisC500Context context)
        {
            _context = context;
        }

        // GET: api/VThoaThuanHopTacQuocTe
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VThoaThuanHopTacQuocTe>>> GetVThoaThuanHopTacQuocTes()
        {
            return await _context.VThoaThuanHopTacQuocTes.ToListAsync();
        }

        // GET: api/VThoaThuanHopTacQuocTe/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VThoaThuanHopTacQuocTe>> GetVThoaThuanHopTacQuocTe(int id)
        {
            var VThoaThuanHopTacQuocTe = await _context.VThoaThuanHopTacQuocTes.FindAsync(id);

            if (VThoaThuanHopTacQuocTe == null)
            {
                return NotFound();
            }

            return VThoaThuanHopTacQuocTe;
        }

    }
}
