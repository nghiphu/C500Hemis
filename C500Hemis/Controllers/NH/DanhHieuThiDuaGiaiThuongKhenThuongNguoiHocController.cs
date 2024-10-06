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
    public class DanhHieuThiDuaGiaiThuongKhenThuongNguoiHocController : Controller
    {
        private readonly HemisContext _context;

        public DanhHieuThiDuaGiaiThuongKhenThuongNguoiHocController(HemisContext context)
        {
            _context = context;
        }

        // GET: DanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHocs.Include(t => t.IdCapKhenThuongNavigation).Include(t => t.IdDanhHieuThiDuaGiaiThuongKhenThuongNavigation).Include(t => t.IdHocVienNavigation).Include(t => t.IdLoaiDanhHieuThiDuaGiaiThuongKhenThuongNavigation).Include(t => t.IdPhuongThucKhenThuongNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: DanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc = await _context.TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHocs
                .Include(t => t.IdCapKhenThuongNavigation)
                .Include(t => t.IdDanhHieuThiDuaGiaiThuongKhenThuongNavigation)
                .Include(t => t.IdHocVienNavigation)
                .Include(t => t.IdLoaiDanhHieuThiDuaGiaiThuongKhenThuongNavigation)
                .Include(t => t.IdPhuongThucKhenThuongNavigation)
                .FirstOrDefaultAsync(m => m.IdDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc == id);
            if (tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc == null)
            {
                return NotFound();
            }

            return View(tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc);
        }

        // GET: DanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc/Create
        public IActionResult Create()
        {
            ViewData["IdCapKhenThuong"] = new SelectList(_context.DmCapKhenThuongs, "IdCapKhenThuong", "IdCapKhenThuong");
            ViewData["IdDanhHieuThiDuaGiaiThuongKhenThuong"] = new SelectList(_context.DmThiDuaGiaiThuongKhenThuongs, "IdThiDuaGiaiThuongKhenThuong", "IdThiDuaGiaiThuongKhenThuong");
            ViewData["IdHocVien"] = new SelectList(_context.TbHocViens, "IdHocVien", "IdHocVien");
            ViewData["IdLoaiDanhHieuThiDuaGiaiThuongKhenThuong"] = new SelectList(_context.DmLoaiDanhHieuThiDuaGiaiThuongKhenThuongs, "IdLoaiDanhHieuThiDuaGiaiThuongKhenThuong", "IdLoaiDanhHieuThiDuaGiaiThuongKhenThuong");
            ViewData["IdPhuongThucKhenThuong"] = new SelectList(_context.DmPhuongThucKhenThuongs, "IdPhuongThucKhenThuong", "IdPhuongThucKhenThuong");
            return View();
        }

        // POST: DanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc,IdHocVien,IdLoaiDanhHieuThiDuaGiaiThuongKhenThuong,IdDanhHieuThiDuaGiaiThuongKhenThuong,SoQuyetDinhKhenThuong,IdPhuongThucKhenThuong,NamKhenThuong,IdCapKhenThuong")] TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCapKhenThuong"] = new SelectList(_context.DmCapKhenThuongs, "IdCapKhenThuong", "IdCapKhenThuong", tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc.IdCapKhenThuong);
            ViewData["IdDanhHieuThiDuaGiaiThuongKhenThuong"] = new SelectList(_context.DmThiDuaGiaiThuongKhenThuongs, "IdThiDuaGiaiThuongKhenThuong", "IdThiDuaGiaiThuongKhenThuong", tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc.IdDanhHieuThiDuaGiaiThuongKhenThuong);
            ViewData["IdHocVien"] = new SelectList(_context.TbHocViens, "IdHocVien", "IdHocVien", tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc.IdHocVien);
            ViewData["IdLoaiDanhHieuThiDuaGiaiThuongKhenThuong"] = new SelectList(_context.DmLoaiDanhHieuThiDuaGiaiThuongKhenThuongs, "IdLoaiDanhHieuThiDuaGiaiThuongKhenThuong", "IdLoaiDanhHieuThiDuaGiaiThuongKhenThuong", tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc.IdLoaiDanhHieuThiDuaGiaiThuongKhenThuong);
            ViewData["IdPhuongThucKhenThuong"] = new SelectList(_context.DmPhuongThucKhenThuongs, "IdPhuongThucKhenThuong", "IdPhuongThucKhenThuong", tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc.IdPhuongThucKhenThuong);
            return View(tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc);
        }

        // GET: DanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc = await _context.TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHocs.FindAsync(id);
            if (tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc == null)
            {
                return NotFound();
            }
            ViewData["IdCapKhenThuong"] = new SelectList(_context.DmCapKhenThuongs, "IdCapKhenThuong", "IdCapKhenThuong", tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc.IdCapKhenThuong);
            ViewData["IdDanhHieuThiDuaGiaiThuongKhenThuong"] = new SelectList(_context.DmThiDuaGiaiThuongKhenThuongs, "IdThiDuaGiaiThuongKhenThuong", "IdThiDuaGiaiThuongKhenThuong", tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc.IdDanhHieuThiDuaGiaiThuongKhenThuong);
            ViewData["IdHocVien"] = new SelectList(_context.TbHocViens, "IdHocVien", "IdHocVien", tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc.IdHocVien);
            ViewData["IdLoaiDanhHieuThiDuaGiaiThuongKhenThuong"] = new SelectList(_context.DmLoaiDanhHieuThiDuaGiaiThuongKhenThuongs, "IdLoaiDanhHieuThiDuaGiaiThuongKhenThuong", "IdLoaiDanhHieuThiDuaGiaiThuongKhenThuong", tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc.IdLoaiDanhHieuThiDuaGiaiThuongKhenThuong);
            ViewData["IdPhuongThucKhenThuong"] = new SelectList(_context.DmPhuongThucKhenThuongs, "IdPhuongThucKhenThuong", "IdPhuongThucKhenThuong", tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc.IdPhuongThucKhenThuong);
            return View(tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc);
        }

        // POST: DanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc,IdHocVien,IdLoaiDanhHieuThiDuaGiaiThuongKhenThuong,IdDanhHieuThiDuaGiaiThuongKhenThuong,SoQuyetDinhKhenThuong,IdPhuongThucKhenThuong,NamKhenThuong,IdCapKhenThuong")] TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc)
        {
            if (id != tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc.IdDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHocExists(tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc.IdDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc))
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
            ViewData["IdCapKhenThuong"] = new SelectList(_context.DmCapKhenThuongs, "IdCapKhenThuong", "IdCapKhenThuong", tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc.IdCapKhenThuong);
            ViewData["IdDanhHieuThiDuaGiaiThuongKhenThuong"] = new SelectList(_context.DmThiDuaGiaiThuongKhenThuongs, "IdThiDuaGiaiThuongKhenThuong", "IdThiDuaGiaiThuongKhenThuong", tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc.IdDanhHieuThiDuaGiaiThuongKhenThuong);
            ViewData["IdHocVien"] = new SelectList(_context.TbHocViens, "IdHocVien", "IdHocVien", tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc.IdHocVien);
            ViewData["IdLoaiDanhHieuThiDuaGiaiThuongKhenThuong"] = new SelectList(_context.DmLoaiDanhHieuThiDuaGiaiThuongKhenThuongs, "IdLoaiDanhHieuThiDuaGiaiThuongKhenThuong", "IdLoaiDanhHieuThiDuaGiaiThuongKhenThuong", tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc.IdLoaiDanhHieuThiDuaGiaiThuongKhenThuong);
            ViewData["IdPhuongThucKhenThuong"] = new SelectList(_context.DmPhuongThucKhenThuongs, "IdPhuongThucKhenThuong", "IdPhuongThucKhenThuong", tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc.IdPhuongThucKhenThuong);
            return View(tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc);
        }

        // GET: DanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc = await _context.TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHocs
                .Include(t => t.IdCapKhenThuongNavigation)
                .Include(t => t.IdDanhHieuThiDuaGiaiThuongKhenThuongNavigation)
                .Include(t => t.IdHocVienNavigation)
                .Include(t => t.IdLoaiDanhHieuThiDuaGiaiThuongKhenThuongNavigation)
                .Include(t => t.IdPhuongThucKhenThuongNavigation)
                .FirstOrDefaultAsync(m => m.IdDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc == id);
            if (tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc == null)
            {
                return NotFound();
            }

            return View(tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc);
        }

        // POST: DanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc = await _context.TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHocs.FindAsync(id);
            if (tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc != null)
            {
                _context.TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHocs.Remove(tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHocExists(int id)
        {
            return _context.TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHocs.Any(e => e.IdDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc == id);
        }
    }
}
