﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HemisApi.Models;

namespace HemisApi.Controllers.KHCN
{
    [Route("api/khcn/[controller]")]
    [ApiController]
    public class vDoanhNghiepKHCNController : ControllerBase
    {
        private readonly DbHemisC500Context _context;

        public vDoanhNghiepKHCNController(DbHemisC500Context context)
        {
            _context = context;
        }

        // GET: api/VDoanhNghiepKHCN
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VDoanhNghiepKhcn>>> GetVDoanhNghiepKHCNs()
        {
            return await _context.VDoanhNghiepKhcns.ToListAsync();
        }

        // GET: api/VDoanhNghiepKHCN/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VDoanhNghiepKhcn>> GetVDoanhNghiepKHCN(int id)
        {
            var VDoanhNghiepKHCN = await _context.VDoanhNghiepKhcns.FindAsync(id);

            if (VDoanhNghiepKHCN == null)
            {
                return NotFound();
            }

            return VDoanhNghiepKHCN;
        }

     
    }
}
