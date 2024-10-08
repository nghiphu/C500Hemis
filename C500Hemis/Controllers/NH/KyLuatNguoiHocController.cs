﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using C500Hemis.Models;

namespace C500Hemis.Controllers.NH
{
    public class KyLuatNguoiHocController : Controller
    {
        private readonly HemisContext _context;

        public KyLuatNguoiHocController(HemisContext context)
        {
            _context = context;
        }

        // GET: KyLuatNguoiHoc
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbKyLuatNguoiHocs.Include(t => t.IdCapQuyetDinhNavigation).Include(t => t.IdHocVienNavigation).Include(t => t.IdLoaiKyLuatNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: KyLuatNguoiHoc/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbKyLuatNguoiHoc = await _context.TbKyLuatNguoiHocs
                .Include(t => t.IdCapQuyetDinhNavigation)
                .Include(t => t.IdHocVienNavigation)
                .Include(t => t.IdLoaiKyLuatNavigation)
                .FirstOrDefaultAsync(m => m.IdKyLuatNguoiHoc == id);
            if (tbKyLuatNguoiHoc == null)
            {
                return NotFound();
            }

            return View(tbKyLuatNguoiHoc);
        }

        // GET: KyLuatNguoiHoc/Create
        public IActionResult Create()
        {
            ViewData["IdCapQuyetDinh"] = new SelectList(_context.DmCapKhenThuongs, "IdCapKhenThuong", "IdCapKhenThuong");
            ViewData["IdHocVien"] = new SelectList(_context.TbHocViens, "IdHocVien", "IdHocVien");
            ViewData["IdLoaiKyLuat"] = new SelectList(_context.DmLoaiKyLuats, "IdLoaiKyLuat", "IdLoaiKyLuat");
            return View();
        }

        // POST: KyLuatNguoiHoc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdKyLuatNguoiHoc,IdHocVien,IdLoaiKyLuat,LyDo,IdCapQuyetDinh,SoQuyetDinh,NgayQuyetDinh,NamBiKyLuat")] TbKyLuatNguoiHoc tbKyLuatNguoiHoc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbKyLuatNguoiHoc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCapQuyetDinh"] = new SelectList(_context.DmCapKhenThuongs, "IdCapKhenThuong", "IdCapKhenThuong", tbKyLuatNguoiHoc.IdCapQuyetDinh);
            ViewData["IdHocVien"] = new SelectList(_context.TbHocViens, "IdHocVien", "IdHocVien", tbKyLuatNguoiHoc.IdHocVien);
            ViewData["IdLoaiKyLuat"] = new SelectList(_context.DmLoaiKyLuats, "IdLoaiKyLuat", "IdLoaiKyLuat", tbKyLuatNguoiHoc.IdLoaiKyLuat);
            return View(tbKyLuatNguoiHoc);
        }

        // GET: KyLuatNguoiHoc/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbKyLuatNguoiHoc = await _context.TbKyLuatNguoiHocs.FindAsync(id);
            if (tbKyLuatNguoiHoc == null)
            {
                return NotFound();
            }
            ViewData["IdCapQuyetDinh"] = new SelectList(_context.DmCapKhenThuongs, "IdCapKhenThuong", "IdCapKhenThuong", tbKyLuatNguoiHoc.IdCapQuyetDinh);
            ViewData["IdHocVien"] = new SelectList(_context.TbHocViens, "IdHocVien", "IdHocVien", tbKyLuatNguoiHoc.IdHocVien);
            ViewData["IdLoaiKyLuat"] = new SelectList(_context.DmLoaiKyLuats, "IdLoaiKyLuat", "IdLoaiKyLuat", tbKyLuatNguoiHoc.IdLoaiKyLuat);
            return View(tbKyLuatNguoiHoc);
        }

        // POST: KyLuatNguoiHoc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdKyLuatNguoiHoc,IdHocVien,IdLoaiKyLuat,LyDo,IdCapQuyetDinh,SoQuyetDinh,NgayQuyetDinh,NamBiKyLuat")] TbKyLuatNguoiHoc tbKyLuatNguoiHoc)
        {
            if (id != tbKyLuatNguoiHoc.IdKyLuatNguoiHoc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbKyLuatNguoiHoc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbKyLuatNguoiHocExists(tbKyLuatNguoiHoc.IdKyLuatNguoiHoc))
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
            ViewData["IdCapQuyetDinh"] = new SelectList(_context.DmCapKhenThuongs, "IdCapKhenThuong", "IdCapKhenThuong", tbKyLuatNguoiHoc.IdCapQuyetDinh);
            ViewData["IdHocVien"] = new SelectList(_context.TbHocViens, "IdHocVien", "IdHocVien", tbKyLuatNguoiHoc.IdHocVien);
            ViewData["IdLoaiKyLuat"] = new SelectList(_context.DmLoaiKyLuats, "IdLoaiKyLuat", "IdLoaiKyLuat", tbKyLuatNguoiHoc.IdLoaiKyLuat);
            return View(tbKyLuatNguoiHoc);
        }

        // GET: KyLuatNguoiHoc/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbKyLuatNguoiHoc = await _context.TbKyLuatNguoiHocs
                .Include(t => t.IdCapQuyetDinhNavigation)
                .Include(t => t.IdHocVienNavigation)
                .Include(t => t.IdLoaiKyLuatNavigation)
                .FirstOrDefaultAsync(m => m.IdKyLuatNguoiHoc == id);
            if (tbKyLuatNguoiHoc == null)
            {
                return NotFound();
            }

            return View(tbKyLuatNguoiHoc);
        }

        // POST: KyLuatNguoiHoc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbKyLuatNguoiHoc = await _context.TbKyLuatNguoiHocs.FindAsync(id);
            if (tbKyLuatNguoiHoc != null)
            {
                _context.TbKyLuatNguoiHocs.Remove(tbKyLuatNguoiHoc);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbKyLuatNguoiHocExists(int id)
        {
            return _context.TbKyLuatNguoiHocs.Any(e => e.IdKyLuatNguoiHoc == id);
        }
    }
}
