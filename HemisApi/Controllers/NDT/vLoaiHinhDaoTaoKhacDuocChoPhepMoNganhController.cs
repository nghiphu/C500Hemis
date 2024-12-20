﻿using System;
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
    public class vLoaiHinhDaoTaoKhacDuocChoPhepMoNganhController : ControllerBase
    {
        private readonly DbHemisC500Context _context;

        public vLoaiHinhDaoTaoKhacDuocChoPhepMoNganhController(DbHemisC500Context context)
        {
            _context = context;
        }

        // GET: api/VLoaiHinhDaoTaoKhacDuocChoPhepMoNganh
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VLoaiHinhDaoTaoKhacDuocChoPhepMoNganh>>> GetVLoaiHinhDaoTaoKhacDuocChoPhepMoNganhs()
        {
            return await _context.VLoaiHinhDaoTaoKhacDuocChoPhepMoNganhs.ToListAsync();
        }

        // GET: api/VLoaiHinhDaoTaoKhacDuocChoPhepMoNganh/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VLoaiHinhDaoTaoKhacDuocChoPhepMoNganh>> GetVLoaiHinhDaoTaoKhacDuocChoPhepMoNganh(int id)
        {
            var VLoaiHinhDaoTaoKhacDuocChoPhepMoNganh = await _context.VLoaiHinhDaoTaoKhacDuocChoPhepMoNganhs.FindAsync(id);

            if (VLoaiHinhDaoTaoKhacDuocChoPhepMoNganh == null)
            {
                return NotFound();
            }

            return VLoaiHinhDaoTaoKhacDuocChoPhepMoNganh;
        }

    }
}
