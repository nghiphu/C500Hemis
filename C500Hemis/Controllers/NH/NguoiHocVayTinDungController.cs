using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using C500Hemis.Models;

namespace C500Hemis.Controllers.NH
{
    public class NguoiHocVayTinDungController : Controller
    {
        private readonly HemisContext _context;

        public NguoiHocVayTinDungController(HemisContext context)
        {
            _context = context;
        }

        // GET: NguoiHocVayTinDung
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbNguoiHocVayTinDungs.Include(t => t.IdHocVienNavigation).Include(t => t.TinhTrangVayNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: NguoiHocVayTinDung/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbNguoiHocVayTinDung = await _context.TbNguoiHocVayTinDungs
                .Include(t => t.IdHocVienNavigation)
                .Include(t => t.TinhTrangVayNavigation)
                .FirstOrDefaultAsync(m => m.IdNguoiHocVayTinDung == id);
            if (tbNguoiHocVayTinDung == null)
            {
                return NotFound();
            }

            return View(tbNguoiHocVayTinDung);
        }

        // GET: NguoiHocVayTinDung/Create
        public IActionResult Create()
        {
            try
            {
                ViewData["IdHocVien"] = new SelectList(_context.TbHocViens, "HocVien", "HocVien");
                ViewData["TinhTrangVay"] = new SelectList(_context.DmTuyChons, "TuyChon", "TuyChon");
                return View();
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        // POST: NguoiHocVayTinDung/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdNguoiHocVayTinDung,IdHocVien,SoTienDuocVay,TenToChucTinDung,NgayVay,DiaChi,ThoiHanVay,TinhTrangVay")] TbNguoiHocVayTinDung tbNguoiHocVayTinDung)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(tbNguoiHocVayTinDung);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["IdHocVien"] = new SelectList(_context.TbHocViens, "IdHocVien", "HocVien", tbNguoiHocVayTinDung.IdHocVien);
                ViewData["TinhTrangVay"] = new SelectList(_context.DmTuyChons, "IdTuyChon", "TuyChon", tbNguoiHocVayTinDung.TinhTrangVay);
                return View(tbNguoiHocVayTinDung);
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        // GET: NguoiHocVayTinDung/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tbNguoiHocVayTinDung = await _context.TbNguoiHocVayTinDungs.FindAsync(id);
                if (tbNguoiHocVayTinDung == null)
                {
                    return NotFound();
                }
                ViewData["IdHocVien"] = new SelectList(_context.TbHocViens, "IdHocVien", "HocVien", tbNguoiHocVayTinDung.IdHocVien);
                ViewData["TinhTrangVay"] = new SelectList(_context.DmTuyChons, "IdTuyChon", "TuyChon", tbNguoiHocVayTinDung.TinhTrangVay);
                return View(tbNguoiHocVayTinDung);
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        // POST: NguoiHocVayTinDung/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdNguoiHocVayTinDung,IdHocVien,SoTienDuocVay,TenToChucTinDung,NgayVay,DiaChi,ThoiHanVay,TinhTrangVay")] TbNguoiHocVayTinDung tbNguoiHocVayTinDung)
        {
            try
            {
                if (id != tbNguoiHocVayTinDung.IdNguoiHocVayTinDung)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(tbNguoiHocVayTinDung);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!TbNguoiHocVayTinDungExists(tbNguoiHocVayTinDung.IdNguoiHocVayTinDung))
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
                ViewData["IdHocVien"] = new SelectList(_context.TbHocViens, "IdHocVien", "HocVien", tbNguoiHocVayTinDung.IdHocVien);
                ViewData["TinhTrangVay"] = new SelectList(_context.DmTuyChons, "IdTuyChon", "TuyChon", tbNguoiHocVayTinDung.TinhTrangVay);
                return View(tbNguoiHocVayTinDung);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // GET: NguoiHocVayTinDung/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tbNguoiHocVayTinDung = await _context.TbNguoiHocVayTinDungs
                    .Include(t => t.IdHocVienNavigation)
                    .Include(t => t.TinhTrangVayNavigation)
                    .FirstOrDefaultAsync(m => m.IdNguoiHocVayTinDung == id);
                if (tbNguoiHocVayTinDung == null)
                {
                    return NotFound();
                }

                return View(tbNguoiHocVayTinDung);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // POST: NguoiHocVayTinDung/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var tbNguoiHocVayTinDung = await _context.TbNguoiHocVayTinDungs.FindAsync(id);
                if (tbNguoiHocVayTinDung != null)
                {
                    _context.TbNguoiHocVayTinDungs.Remove(tbNguoiHocVayTinDung);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        private bool TbNguoiHocVayTinDungExists(int id)
        {
            return _context.TbNguoiHocVayTinDungs.Any(e => e.IdNguoiHocVayTinDung == id);
        }
    }
}
