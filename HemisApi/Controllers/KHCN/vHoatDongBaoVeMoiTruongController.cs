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
    public class vHoatDongBaoVeMoiTruongController : ControllerBase
    {
        private readonly DbHemisC500Context _context;

        public vHoatDongBaoVeMoiTruongController(DbHemisC500Context context)
        {
            _context = context;
        }

        // GET: api/VHoatDongBaoVeMoiTruong
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VHoatDongBaoVeMoiTruong>>> GetVHoatDongBaoVeMoiTruongs()
        {
            return await _context.VHoatDongBaoVeMoiTruongs.ToListAsync();
        }

        // GET: api/VHoatDongBaoVeMoiTruong/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VHoatDongBaoVeMoiTruong>> GetVHoatDongBaoVeMoiTruong(int id)
        {
            var VHoatDongBaoVeMoiTruong = await _context.VHoatDongBaoVeMoiTruongs.FindAsync(id);

            if (VHoatDongBaoVeMoiTruong == null)
            {
                return NotFound();
            }

            return VHoatDongBaoVeMoiTruong;
        }

    }
}
