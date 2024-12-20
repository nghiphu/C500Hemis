﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HemisApi.Models;

namespace HemisApi.Controllers.NH
{
    [Route("api/nh/[controller]")]
    [ApiController]
    public class vThongTinHocTapSinhVienController : ControllerBase
    {
        private readonly DbHemisC500Context _context;

        public vThongTinHocTapSinhVienController(DbHemisC500Context context)
        {
            _context = context;
        }

        // GET: api/VThongTinHocTapSinhVien
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VThongTinHocTapSinhVien>>> GetVThongTinHocTapSinhViens()
        {
            return await _context.VThongTinHocTapSinhViens.ToListAsync();
        }

        // GET: api/VThongTinHocTapSinhVien/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VThongTinHocTapSinhVien>> GetVThongTinHocTapSinhVien(int id)
        {
            var VThongTinHocTapSinhVien = await _context.VThongTinHocTapSinhViens.FindAsync(id);

            if (VThongTinHocTapSinhVien == null)
            {
                return NotFound();
            }

            return VThongTinHocTapSinhVien;
        }

        
    }
}
