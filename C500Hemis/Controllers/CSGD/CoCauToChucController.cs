﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using C500Hemis.Models;

namespace C500Hemis.Controllers.CSGD
{
    public class CoCauToChucController : Controller
    {
        private readonly HemisContext _context;

        public CoCauToChucController(HemisContext context)
        {
            _context = context;
        }

        // GET: CoCauToChuc
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbCoCauToChucs.Include(t => t.IdLoaiPhongBanNavigation).Include(t => t.IdTrangThaiNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: CoCauToChuc/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbCoCauToChuc = await _context.TbCoCauToChucs
                .Include(t => t.IdLoaiPhongBanNavigation)
                .Include(t => t.IdTrangThaiNavigation)
                .FirstOrDefaultAsync(m => m.IdCoCauToChuc == id);
            if (tbCoCauToChuc == null)
            {
                return NotFound();
            }

            return View(tbCoCauToChuc);
        }

        // GET: CoCauToChuc/Create
        public IActionResult Create()
        {
            ViewData["IdLoaiPhongBan"] = new SelectList(_context.DmLoaiPhongBans, "IdLoaiPhongBan", "IdLoaiPhongBan");
            ViewData["IdTrangThai"] = new SelectList(_context.DmTrangThaiCoSoGds, "IdTrangThaiCoSoGd", "IdTrangThaiCoSoGd");
            return View();
        }

        // POST: CoCauToChuc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCoCauToChuc,MaPhongBanDonVi,IdLoaiPhongBan,MaPhongBanDonViCha,TenPhongBanDonVi,SoQuyetDinhThanhLap,NgayRaQuyetDinh,IdTrangThai")] TbCoCauToChuc tbCoCauToChuc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbCoCauToChuc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdLoaiPhongBan"] = new SelectList(_context.DmLoaiPhongBans, "IdLoaiPhongBan", "IdLoaiPhongBan", tbCoCauToChuc.IdLoaiPhongBan);
            ViewData["IdTrangThai"] = new SelectList(_context.DmTrangThaiCoSoGds, "IdTrangThaiCoSoGd", "IdTrangThaiCoSoGd", tbCoCauToChuc.IdTrangThai);
            return View(tbCoCauToChuc);
        }

        // GET: CoCauToChuc/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbCoCauToChuc = await _context.TbCoCauToChucs.FindAsync(id);
            if (tbCoCauToChuc == null)
            {
                return NotFound();
            }
            ViewData["IdLoaiPhongBan"] = new SelectList(_context.DmLoaiPhongBans, "IdLoaiPhongBan", "IdLoaiPhongBan", tbCoCauToChuc.IdLoaiPhongBan);
            ViewData["IdTrangThai"] = new SelectList(_context.DmTrangThaiCoSoGds, "IdTrangThaiCoSoGd", "IdTrangThaiCoSoGd", tbCoCauToChuc.IdTrangThai);
            return View(tbCoCauToChuc);
        }

        // POST: CoCauToChuc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCoCauToChuc,MaPhongBanDonVi,IdLoaiPhongBan,MaPhongBanDonViCha,TenPhongBanDonVi,SoQuyetDinhThanhLap,NgayRaQuyetDinh,IdTrangThai")] TbCoCauToChuc tbCoCauToChuc)
        {
            if (id != tbCoCauToChuc.IdCoCauToChuc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbCoCauToChuc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbCoCauToChucExists(tbCoCauToChuc.IdCoCauToChuc))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdLoaiPhongBan"] = new SelectList(_context.DmLoaiPhongBans, "IdLoaiPhongBan", "IdLoaiPhongBan", tbCoCauToChuc.IdLoaiPhongBan);
            ViewData["IdTrangThai"] = new SelectList(_context.DmTrangThaiCoSoGds, "IdTrangThaiCoSoGd", "IdTrangThaiCoSoGd", tbCoCauToChuc.IdTrangThai);
            return View(tbCoCauToChuc);
        }

        // GET: CoCauToChuc/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbCoCauToChuc = await _context.TbCoCauToChucs
                .Include(t => t.IdLoaiPhongBanNavigation)
                .Include(t => t.IdTrangThaiNavigation)
                .FirstOrDefaultAsync(m => m.IdCoCauToChuc == id);
            if (tbCoCauToChuc == null)
            {
                return NotFound();
            }

            return View(tbCoCauToChuc);
        }

        // POST: CoCauToChuc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbCoCauToChuc = await _context.TbCoCauToChucs.FindAsync(id);
            if (tbCoCauToChuc != null)
            {
                _context.TbCoCauToChucs.Remove(tbCoCauToChuc);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbCoCauToChucExists(int id)
        {
            return _context.TbCoCauToChucs.Any(e => e.IdCoCauToChuc == id);
        }
    }
}
