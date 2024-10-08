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
    public class ThongTinHocTapNghienCuuSinhController : Controller
    {
        private readonly HemisContext _context;

        public ThongTinHocTapNghienCuuSinhController(HemisContext context)
        {
            _context = context;
        }

        // GET: ThongTinHocTapNghienCuuSinh
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbThongTinHocTapNghienCuuSinhs.Include(t => t.IdChuongTrinhDaoTaoNavigation).Include(t => t.IdDoiTuongDauVaoNavigation).Include(t => t.IdHocVienNavigation).Include(t => t.IdLoaiHinhDaoTaoNavigation).Include(t => t.IdLoaiTotNghiepNavigation).Include(t => t.IdNguoiHuongDanChinhNavigation).Include(t => t.IdNguoiHuongDanPhuNavigation).Include(t => t.IdSinhVienNamNavigation).Include(t => t.IdTrangThaiHocNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: ThongTinHocTapNghienCuuSinh/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbThongTinHocTapNghienCuuSinh = await _context.TbThongTinHocTapNghienCuuSinhs
                .Include(t => t.IdChuongTrinhDaoTaoNavigation)
                .Include(t => t.IdDoiTuongDauVaoNavigation)
                .Include(t => t.IdHocVienNavigation)
                .Include(t => t.IdLoaiHinhDaoTaoNavigation)
                .Include(t => t.IdLoaiTotNghiepNavigation)
                .Include(t => t.IdNguoiHuongDanChinhNavigation)
                .Include(t => t.IdNguoiHuongDanPhuNavigation)
                .Include(t => t.IdSinhVienNamNavigation)
                .Include(t => t.IdTrangThaiHocNavigation)
                .FirstOrDefaultAsync(m => m.IdThongTinHocTapNghienCuuSinh == id);
            if (tbThongTinHocTapNghienCuuSinh == null)
            {
                return NotFound();
            }

            return View(tbThongTinHocTapNghienCuuSinh);
        }

        // GET: ThongTinHocTapNghienCuuSinh/Create
        public IActionResult Create()
        {
            ViewData["IdChuongTrinhDaoTao"] = new SelectList(_context.DmChuongTrinhDaoTaos, "IdChuongTrinhDaoTao", "IdChuongTrinhDaoTao");
            ViewData["IdDoiTuongDauVao"] = new SelectList(_context.DmDoiTuongDauVaos, "IdDoiTuongDauVao", "IdDoiTuongDauVao");
            ViewData["IdHocVien"] = new SelectList(_context.TbHocViens, "IdHocVien", "IdHocVien");
            ViewData["IdLoaiHinhDaoTao"] = new SelectList(_context.DmLoaiHinhDaoTaos, "IdLoaiHinhDaoTao", "IdLoaiHinhDaoTao");
            ViewData["IdLoaiTotNghiep"] = new SelectList(_context.DmLoaiTotNghieps, "IdLoaiTotNghiep", "IdLoaiTotNghiep");
            ViewData["IdNguoiHuongDanChinh"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo");
            ViewData["IdNguoiHuongDanPhu"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo");
            ViewData["IdSinhVienNam"] = new SelectList(_context.DmSinhVienNams, "IdSinhVienNam", "IdSinhVienNam");
            ViewData["IdTrangThaiHoc"] = new SelectList(_context.DmTrangThaiHocs, "IdTrangThaiHoc", "IdTrangThaiHoc");
            return View();
        }

        // POST: ThongTinHocTapNghienCuuSinh/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdThongTinHocTapNghienCuuSinh,IdHocVien,IdDoiTuongDauVao,IdSinhVienNam,IdChuongTrinhDaoTao,IdLoaiHinhDaoTao,DaoTaoTuNam,DaoTaoDenNam,NgayNhapHoc,IdTrangThaiHoc,NgayChuyenTrangThai,SoQuyetDinhThoiHoc,TenLuanVan,NgayBaoVeCapTruong,NgayBaoVeCapCoSo,QuyChuanNguoiHuongDan,IdNguoiHuongDanChinh,IdNguoiHuongDanPhu,SoQuyetDinhCongNhan,NgayQuyetDinhCongNhan,IdLoaiTotNghiep,SoQuyetDinhThanhLapHoiDongBaoVeCapCoSo,NgayQuyetDinhThanhLapHoiDongBaoVeCapCoSo,SoQuyetDinhThanhLapHoiDongBaoVeCapTruong,NgayQuyetDinhThanhLapHoiDongBaoVeCapTruong")] TbThongTinHocTapNghienCuuSinh tbThongTinHocTapNghienCuuSinh)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbThongTinHocTapNghienCuuSinh);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdChuongTrinhDaoTao"] = new SelectList(_context.DmChuongTrinhDaoTaos, "IdChuongTrinhDaoTao", "IdChuongTrinhDaoTao", tbThongTinHocTapNghienCuuSinh.IdChuongTrinhDaoTao);
            ViewData["IdDoiTuongDauVao"] = new SelectList(_context.DmDoiTuongDauVaos, "IdDoiTuongDauVao", "IdDoiTuongDauVao", tbThongTinHocTapNghienCuuSinh.IdDoiTuongDauVao);
            ViewData["IdHocVien"] = new SelectList(_context.TbHocViens, "IdHocVien", "IdHocVien", tbThongTinHocTapNghienCuuSinh.IdHocVien);
            ViewData["IdLoaiHinhDaoTao"] = new SelectList(_context.DmLoaiHinhDaoTaos, "IdLoaiHinhDaoTao", "IdLoaiHinhDaoTao", tbThongTinHocTapNghienCuuSinh.IdLoaiHinhDaoTao);
            ViewData["IdLoaiTotNghiep"] = new SelectList(_context.DmLoaiTotNghieps, "IdLoaiTotNghiep", "IdLoaiTotNghiep", tbThongTinHocTapNghienCuuSinh.IdLoaiTotNghiep);
            ViewData["IdNguoiHuongDanChinh"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo", tbThongTinHocTapNghienCuuSinh.IdNguoiHuongDanChinh);
            ViewData["IdNguoiHuongDanPhu"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo", tbThongTinHocTapNghienCuuSinh.IdNguoiHuongDanPhu);
            ViewData["IdSinhVienNam"] = new SelectList(_context.DmSinhVienNams, "IdSinhVienNam", "IdSinhVienNam", tbThongTinHocTapNghienCuuSinh.IdSinhVienNam);
            ViewData["IdTrangThaiHoc"] = new SelectList(_context.DmTrangThaiHocs, "IdTrangThaiHoc", "IdTrangThaiHoc", tbThongTinHocTapNghienCuuSinh.IdTrangThaiHoc);
            return View(tbThongTinHocTapNghienCuuSinh);
        }

        // GET: ThongTinHocTapNghienCuuSinh/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbThongTinHocTapNghienCuuSinh = await _context.TbThongTinHocTapNghienCuuSinhs.FindAsync(id);
            if (tbThongTinHocTapNghienCuuSinh == null)
            {
                return NotFound();
            }
            ViewData["IdChuongTrinhDaoTao"] = new SelectList(_context.DmChuongTrinhDaoTaos, "IdChuongTrinhDaoTao", "IdChuongTrinhDaoTao", tbThongTinHocTapNghienCuuSinh.IdChuongTrinhDaoTao);
            ViewData["IdDoiTuongDauVao"] = new SelectList(_context.DmDoiTuongDauVaos, "IdDoiTuongDauVao", "IdDoiTuongDauVao", tbThongTinHocTapNghienCuuSinh.IdDoiTuongDauVao);
            ViewData["IdHocVien"] = new SelectList(_context.TbHocViens, "IdHocVien", "IdHocVien", tbThongTinHocTapNghienCuuSinh.IdHocVien);
            ViewData["IdLoaiHinhDaoTao"] = new SelectList(_context.DmLoaiHinhDaoTaos, "IdLoaiHinhDaoTao", "IdLoaiHinhDaoTao", tbThongTinHocTapNghienCuuSinh.IdLoaiHinhDaoTao);
            ViewData["IdLoaiTotNghiep"] = new SelectList(_context.DmLoaiTotNghieps, "IdLoaiTotNghiep", "IdLoaiTotNghiep", tbThongTinHocTapNghienCuuSinh.IdLoaiTotNghiep);
            ViewData["IdNguoiHuongDanChinh"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo", tbThongTinHocTapNghienCuuSinh.IdNguoiHuongDanChinh);
            ViewData["IdNguoiHuongDanPhu"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo", tbThongTinHocTapNghienCuuSinh.IdNguoiHuongDanPhu);
            ViewData["IdSinhVienNam"] = new SelectList(_context.DmSinhVienNams, "IdSinhVienNam", "IdSinhVienNam", tbThongTinHocTapNghienCuuSinh.IdSinhVienNam);
            ViewData["IdTrangThaiHoc"] = new SelectList(_context.DmTrangThaiHocs, "IdTrangThaiHoc", "IdTrangThaiHoc", tbThongTinHocTapNghienCuuSinh.IdTrangThaiHoc);
            return View(tbThongTinHocTapNghienCuuSinh);
        }

        // POST: ThongTinHocTapNghienCuuSinh/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdThongTinHocTapNghienCuuSinh,IdHocVien,IdDoiTuongDauVao,IdSinhVienNam,IdChuongTrinhDaoTao,IdLoaiHinhDaoTao,DaoTaoTuNam,DaoTaoDenNam,NgayNhapHoc,IdTrangThaiHoc,NgayChuyenTrangThai,SoQuyetDinhThoiHoc,TenLuanVan,NgayBaoVeCapTruong,NgayBaoVeCapCoSo,QuyChuanNguoiHuongDan,IdNguoiHuongDanChinh,IdNguoiHuongDanPhu,SoQuyetDinhCongNhan,NgayQuyetDinhCongNhan,IdLoaiTotNghiep,SoQuyetDinhThanhLapHoiDongBaoVeCapCoSo,NgayQuyetDinhThanhLapHoiDongBaoVeCapCoSo,SoQuyetDinhThanhLapHoiDongBaoVeCapTruong,NgayQuyetDinhThanhLapHoiDongBaoVeCapTruong")] TbThongTinHocTapNghienCuuSinh tbThongTinHocTapNghienCuuSinh)
        {
            if (id != tbThongTinHocTapNghienCuuSinh.IdThongTinHocTapNghienCuuSinh)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbThongTinHocTapNghienCuuSinh);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbThongTinHocTapNghienCuuSinhExists(tbThongTinHocTapNghienCuuSinh.IdThongTinHocTapNghienCuuSinh))
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
            ViewData["IdChuongTrinhDaoTao"] = new SelectList(_context.DmChuongTrinhDaoTaos, "IdChuongTrinhDaoTao", "IdChuongTrinhDaoTao", tbThongTinHocTapNghienCuuSinh.IdChuongTrinhDaoTao);
            ViewData["IdDoiTuongDauVao"] = new SelectList(_context.DmDoiTuongDauVaos, "IdDoiTuongDauVao", "IdDoiTuongDauVao", tbThongTinHocTapNghienCuuSinh.IdDoiTuongDauVao);
            ViewData["IdHocVien"] = new SelectList(_context.TbHocViens, "IdHocVien", "IdHocVien", tbThongTinHocTapNghienCuuSinh.IdHocVien);
            ViewData["IdLoaiHinhDaoTao"] = new SelectList(_context.DmLoaiHinhDaoTaos, "IdLoaiHinhDaoTao", "IdLoaiHinhDaoTao", tbThongTinHocTapNghienCuuSinh.IdLoaiHinhDaoTao);
            ViewData["IdLoaiTotNghiep"] = new SelectList(_context.DmLoaiTotNghieps, "IdLoaiTotNghiep", "IdLoaiTotNghiep", tbThongTinHocTapNghienCuuSinh.IdLoaiTotNghiep);
            ViewData["IdNguoiHuongDanChinh"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo", tbThongTinHocTapNghienCuuSinh.IdNguoiHuongDanChinh);
            ViewData["IdNguoiHuongDanPhu"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo", tbThongTinHocTapNghienCuuSinh.IdNguoiHuongDanPhu);
            ViewData["IdSinhVienNam"] = new SelectList(_context.DmSinhVienNams, "IdSinhVienNam", "IdSinhVienNam", tbThongTinHocTapNghienCuuSinh.IdSinhVienNam);
            ViewData["IdTrangThaiHoc"] = new SelectList(_context.DmTrangThaiHocs, "IdTrangThaiHoc", "IdTrangThaiHoc", tbThongTinHocTapNghienCuuSinh.IdTrangThaiHoc);
            return View(tbThongTinHocTapNghienCuuSinh);
        }

        // GET: ThongTinHocTapNghienCuuSinh/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbThongTinHocTapNghienCuuSinh = await _context.TbThongTinHocTapNghienCuuSinhs
                .Include(t => t.IdChuongTrinhDaoTaoNavigation)
                .Include(t => t.IdDoiTuongDauVaoNavigation)
                .Include(t => t.IdHocVienNavigation)
                .Include(t => t.IdLoaiHinhDaoTaoNavigation)
                .Include(t => t.IdLoaiTotNghiepNavigation)
                .Include(t => t.IdNguoiHuongDanChinhNavigation)
                .Include(t => t.IdNguoiHuongDanPhuNavigation)
                .Include(t => t.IdSinhVienNamNavigation)
                .Include(t => t.IdTrangThaiHocNavigation)
                .FirstOrDefaultAsync(m => m.IdThongTinHocTapNghienCuuSinh == id);
            if (tbThongTinHocTapNghienCuuSinh == null)
            {
                return NotFound();
            }

            return View(tbThongTinHocTapNghienCuuSinh);
        }

        // POST: ThongTinHocTapNghienCuuSinh/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbThongTinHocTapNghienCuuSinh = await _context.TbThongTinHocTapNghienCuuSinhs.FindAsync(id);
            if (tbThongTinHocTapNghienCuuSinh != null)
            {
                _context.TbThongTinHocTapNghienCuuSinhs.Remove(tbThongTinHocTapNghienCuuSinh);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbThongTinHocTapNghienCuuSinhExists(int id)
        {
            return _context.TbThongTinHocTapNghienCuuSinhs.Any(e => e.IdThongTinHocTapNghienCuuSinh == id);
        }
    }
}
