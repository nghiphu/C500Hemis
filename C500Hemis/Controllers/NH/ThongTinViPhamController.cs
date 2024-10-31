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
    public class ThongTinViPhamController : Controller
    {
        private readonly HemisContext _context;

        public ThongTinViPhamController(HemisContext context)
        {
            _context = context;
        }

        // GET: ThongTinViPham
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbThongTinViPhams.Include(t => t.IdHocVienNavigation).Include(t => t.IdHocVienNavigation.IdNguoiNavigation);
            return View(await hemisContext.ToListAsync());

        }

        // GET: ThongTinViPham/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tbThongTinViPham = await _context.TbThongTinViPhams
                    .Include(t => t.IdHocVienNavigation)
                    .Include(t => t.IdLoaiViPhamNavigation)
                    .FirstOrDefaultAsync(m => m.IdThongTinViPham == id);
                if (tbThongTinViPham == null)
                {
                    return NotFound();
                }

                return View(tbThongTinViPham);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: ThongTinViPham/Create
        public IActionResult Create()
        {
            try
            {
                ViewData["IdHocVien"] = new SelectList(_context.TbHocViens.Include(h => h.IdNguoiNavigation), "IdHocVien", "IdNguoiNavigation.name");
                ViewData["IdLoaiViPham"] = new SelectList(_context.DmLoaiViPhams, "IdLoaiViPham", "LoaiViPham");
                return View();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: ThongTinViPham/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdThongTinViPham,IdHocVien,ThoiGianViPham,NoiDungViPham,HinhThucXuLy,IdLoaiViPham")] TbThongTinViPham tbThongTinViPham)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Add(tbThongTinViPham); // Thêm vi phạm vào context
                        await _context.SaveChangesAsync(); // Lưu thay đổi vào cơ sở dữ liệu
                        return RedirectToAction(nameof(Index)); // Chuyển hướng về danh sách
                    }
                    catch (DbUpdateException dbEx)
                    {
                        // Lỗi liên quan đến cơ sở dữ liệu như khóa chính, khóa ngoại
                        ModelState.AddModelError("", "Không thể lưu dữ liệu vào cơ sở dữ liệu vì trùng ID ");
                        return View(tbThongTinViPham);
                    }
                    catch (Exception ex)
                    {
                        // Lỗi chung chung khác
                        ModelState.AddModelError("", "Đã xảy ra lỗi: " + ex.Message);
                        return View(tbThongTinViPham);
                    }
                }
                ViewData["IdHocVien"] = new SelectList(_context.TbHocViens.Include(h => h.IdNguoiNavigation), "IdHocVien", "IdNguoiNavigation.name", tbThongTinViPham.IdHocVien);
                ViewData["IdLoaiViPham"] = new SelectList(_context.DmLoaiViPhams, "IdLoaiViPham", "LoaiViPham", tbThongTinViPham.IdLoaiViPham);
                return View(tbThongTinViPham);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // GET: ThongTinViPham/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tbThongTinViPham = await _context.TbThongTinViPhams.FindAsync(id);
                if (tbThongTinViPham == null)
                {
                    return NotFound();
                }
                ViewData["IdHocVien"] = new SelectList(_context.TbHocViens.Include(h => h.IdNguoiNavigation), "IdHocVien", "IdNguoiNavigation.name", tbThongTinViPham.IdHocVien);
                ViewData["IdLoaiViPham"] = new SelectList(_context.DmLoaiViPhams, "IdLoaiViPham", "LoaiViPham", tbThongTinViPham.IdLoaiViPham);
                return View(tbThongTinViPham);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // POST: ThongTinViPham/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdThongTinViPham,IdHocVien,ThoiGianViPham,NoiDungViPham,HinhThucXuLy,IdLoaiViPham")] TbThongTinViPham tbThongTinViPham)
        {
            try
            {
                if (id != tbThongTinViPham.IdThongTinViPham)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(tbThongTinViPham);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!TbThongTinViPhamExists(tbThongTinViPham.IdThongTinViPham))
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
                ViewData["IdHocVien"] = new SelectList(_context.TbHocViens.Include(h => h.IdNguoiNavigation), "IdHocVien", "IdNguoiNavigation.name", tbThongTinViPham.IdHocVien);
                ViewData["IdLoaiViPham"] = new SelectList(_context.DmLoaiViPhams, "IdLoaiViPham", "LoaiViPham", tbThongTinViPham.IdLoaiViPham);
                return View(tbThongTinViPham);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        // GET: ThongTinViPham/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tbThongTinViPham = await _context.TbThongTinViPhams
                    .Include(t => t.IdHocVienNavigation)
                    .Include(t => t.IdLoaiViPhamNavigation)
                    .FirstOrDefaultAsync(m => m.IdThongTinViPham == id);
                if (tbThongTinViPham == null)
                {
                    return NotFound();
                }

                return View(tbThongTinViPham);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
        // POST: ThongTinViPham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var tbThongTinViPham = await _context.TbThongTinViPhams.FindAsync(id);
                if (tbThongTinViPham != null)
                {
                    _context.TbThongTinViPhams.Remove(tbThongTinViPham);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        private bool TbThongTinViPhamExists(int id)
        {
            return _context.TbThongTinViPhams.Any(e => e.IdThongTinViPham == id);
        }
    }
}