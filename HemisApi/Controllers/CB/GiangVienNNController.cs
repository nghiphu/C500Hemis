﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HemisApi.Models;

namespace HemisApi.Controllers.CB
{
    [Route("api/cb/[controller]")]
    [ApiController]
    public class GiangVienNNController : ControllerBase
    {
        private readonly DbHemisC500Context _context;

        public GiangVienNNController(DbHemisC500Context context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbGiangVienNn>>> GetTbGiangVienNns()
        {
            return await _context.TbGiangVienNns.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbGiangVienNn>> GetTbGiangVienNn(int id)
        {
            var TbGiangVienNn = await _context.TbGiangVienNns.FindAsync(id);

            if (TbGiangVienNn == null)
            {
                return NotFound();
            }

            return TbGiangVienNn;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbGiangVienNn(int id, TbGiangVienNn TbGiangVienNn)
        {
            if (id != TbGiangVienNn.IdGvnn)
            {
                return BadRequest();
            }

            _context.Entry(TbGiangVienNn).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbGiangVienNnExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CanBo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbGiangVienNn>> PostTbGiangVienNn(TbGiangVienNn TbGiangVienNn)
        {
            _context.TbGiangVienNns.Add(TbGiangVienNn);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbGiangVienNnExists(TbGiangVienNn.IdGvnn))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbGiangVienNn", new { id = TbGiangVienNn.IdGvnn }, TbGiangVienNn);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbGiangVienNn(int id)
        {
            var TbGiangVienNn = await _context.TbGiangVienNns.FindAsync(id);
            if (TbGiangVienNn == null)
            {
                return NotFound();
            }

            _context.TbGiangVienNns.Remove(TbGiangVienNn);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbGiangVienNnExists(int id)
        {
            return _context.TbGiangVienNns.Any(e => e.IdGvnn == id);
        }
    }
}
