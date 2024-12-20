﻿using System;
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
    public class vQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoaiController : ControllerBase
    {
        private readonly DbHemisC500Context _context;

        public vQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoaiController(DbHemisC500Context context)
        {
            _context = context;
        }

        // GET: api/VQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai>>> GetVQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoais()
        {
            return await _context.VQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoais.ToListAsync();
        }

        // GET: api/VQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai>> GetVQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai(int id)
        {
            var VQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai = await _context.VQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoais.FindAsync(id);

            if (VQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai == null)
            {
                return NotFound();
            }

            return VQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai;
        }

      
    }
}
