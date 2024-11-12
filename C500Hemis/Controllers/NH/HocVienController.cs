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
    public class HocVienController : Controller
    {
        private readonly HemisContext _context;

        public HocVienController(HemisContext context)
        {
            _context = context;
        }

        // GET: HocVien
        public async Task<IActionResult> Index()
        {
            try
            {
                var hemisContext = _context.TbHocViens
                    .Include(t => t.IdHuyenNavigation)
                    .Include(t => t.IdLoaiKhuyetTatNavigation)
                    .Include(t => t.IdNguoiNavigation)
                    .Include(t => t.IdTinhNavigation)
                    .Include(t => t.IdXaNavigation);

                return View(await hemisContext.ToListAsync());
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // GET: HocVien/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null) return NotFound();

                var tbHocVien = await _context.TbHocViens
                    .Include(t => t.IdHuyenNavigation)
                    .Include(t => t.IdLoaiKhuyetTatNavigation)
                    .Include(t => t.IdNguoiNavigation)
                    .Include(t => t.IdTinhNavigation)
                    .Include(t => t.IdXaNavigation)
                    .FirstOrDefaultAsync(m => m.IdHocVien == id);

                if (tbHocVien == null) return NotFound();

                return View(tbHocVien);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // GET: HocVien/Create
        public IActionResult Create()
        {
            try
            {
                ViewData["IdHuyen"] = new SelectList(_context.DmHuyens, "IdHuyen", "TenHuyen");
                ViewData["IdLoaiKhuyetTat"] = new SelectList(_context.DmLoaiKhuyetTats, "IdLoaiKhuyetTat", "LoaiKhuyetTat");
                ViewData["IdNguoi"] = new SelectList(_context.TbNguois, "IdNguoi", "name");
                ViewData["IdTinh"] = new SelectList(_context.DmTinhs, "IdTinh", "TenTinh");
                ViewData["IdXa"] = new SelectList(_context.DmXas, "IdXa", "TenXa");

                return View();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // POST: HocVien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        private async Task<bool> existId(int id)
        {
            return await _context.TbHocViens.AnyAsync(e => e.IdHocVien == id);
        }
        // POST: HocVien/Create
        // POST: HocVien/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdHocVien,MaHocVien,IdNguoi,Email,Sdt,SoSoBaoHiem,IdLoaiKhuyetTat,IdTinh,IdHuyen,IdXa,NoiSinh,QueQuan")] TbHocVien tbHocVien)
        {
            try
            {

                if (await existId(tbHocVien.MaHocVien)) ModelState.AddModelError("MaHocVien", "Đã tồn tại mã này!");
                Console.WriteLine($"Kiểm tra IdHocVien: {tbHocVien.IdHocVien}");


                // Nếu đã tồn tại thì thêm Error cho IdHocVien
                if (await existId(tbHocVien.IdHocVien))
                {
                    ModelState.AddModelError("IdHocVien", "Đã tồn tại Id này!");
                }

                Console.WriteLine($"ModelState IsValid: {ModelState.IsValid}");

                if (ModelState.IsValid)
                {
                    _context.Add(tbHocVien);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

                // Cập nhật ViewData nếu có lỗi
                ViewData["IdHuyen"] = new SelectList(_context.DmHuyens, "IdHuyen", "TenHuyen", tbHocVien.IdHuyen);
                ViewData["IdLoaiKhuyetTat"] = new SelectList(_context.DmLoaiKhuyetTats, "IdLoaiKhuyetTat", "LoaiKhuyetTat", tbHocVien.IdLoaiKhuyetTat);
                ViewData["IdNguoi"] = new SelectList(_context.TbNguois, "IdNguoi", "name", tbHocVien.IdNguoi);
                ViewData["IdTinh"] = new SelectList(_context.DmTinhs, "IdTinh", "TenTinh", tbHocVien.IdTinh);
                ViewData["IdXa"] = new SelectList(_context.DmXas, "IdXa", "TenXa", tbHocVien.IdXa);

                return View(tbHocVien);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return BadRequest(ex.Message); // Trả về thông báo lỗi
            }
        }



        // GET: HocVien/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null) return NotFound();

                var tbHocVien = await _context.TbHocViens.FindAsync(id);
                if (tbHocVien == null) return NotFound();

                ViewData["IdHuyen"] = new SelectList(_context.DmHuyens, "IdHuyen", "TenHuyen", tbHocVien.IdHuyen);
                ViewData["IdLoaiKhuyetTat"] = new SelectList(_context.DmLoaiKhuyetTats, "IdLoaiKhuyetTat", "LoaiKhuyetTat", tbHocVien.IdLoaiKhuyetTat);
                ViewData["IdNguoi"] = new SelectList(_context.TbNguois, "IdNguoi", "name", tbHocVien.IdNguoi);
                ViewData["IdTinh"] = new SelectList(_context.DmTinhs, "IdTinh", "TenTinh", tbHocVien.IdTinh);
                ViewData["IdXa"] = new SelectList(_context.DmXas, "IdXa", "TenXa", tbHocVien.IdXa);

                return View(tbHocVien);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // POST: HocVien/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdHocVien,MaHocVien,IdNguoi,Email,Sdt,SoSoBaoHiem,IdLoaiKhuyetTat,IdTinh,IdHuyen,IdXa,NoiSinh,QueQuan")] TbHocVien tbHocVien)
        {
            try
            {
                Console.WriteLine($"Kiểm tra IdHocVien: {tbHocVien.IdHocVien}");

                if (id != tbHocVien.IdHocVien)
                {
                    Console.WriteLine("Id không khớp, không tìm thấy đối tượng");
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(tbHocVien);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!TbHocVienExists(tbHocVien.IdHocVien))
                        {
                            Console.WriteLine("Không tìm thấy Id này trong CSDL, đối tượng đã bị xóa hoặc không tồn tại");
                            return NotFound();
                        }
                        else
                        {
                            Console.WriteLine("Lỗi cạnh tranh dữ liệu (concurrency)");
                            throw;
                        }
                    }

                    return RedirectToAction(nameof(Index));
                }

                // Cập nhật ViewData khi có lỗi
                ViewData["IdHuyen"] = new SelectList(_context.DmHuyens, "IdHuyen", "TenHuyen", tbHocVien.IdHuyen);
                ViewData["IdLoaiKhuyetTat"] = new SelectList(_context.DmLoaiKhuyetTats, "IdLoaiKhuyetTat", "LoaiKhuyetTat", tbHocVien.IdLoaiKhuyetTat);
                ViewData["IdNguoi"] = new SelectList(_context.TbNguois, "IdNguoi", "name", tbHocVien.IdNguoi);
                ViewData["IdTinh"] = new SelectList(_context.DmTinhs, "IdTinh", "TenTinh", tbHocVien.IdTinh);
                ViewData["IdXa"] = new SelectList(_context.DmXas, "IdXa", "TenXa", tbHocVien.IdXa);

                return View(tbHocVien);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }


        // GET: HocVien/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null) return NotFound();

                var tbHocVien = await _context.TbHocViens
                    .Include(t => t.IdHuyenNavigation)
                    .Include(t => t.IdLoaiKhuyetTatNavigation)
                    .Include(t => t.IdNguoiNavigation)
                    .Include(t => t.IdTinhNavigation)
                    .Include(t => t.IdXaNavigation)
                    .FirstOrDefaultAsync(m => m.IdHocVien == id);
                if (tbHocVien == null)
                {
                    Console.WriteLine("Foreign Key Constraint Violation.");
                    return BadRequest();
                }
                return View(tbHocVien);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: HocVien/Delete/5
        [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                try
                {
                    var tbHocVien = await _context.TbHocViens.FindAsync(id);
                    if (tbHocVien != null) _context.TbHocViens.Remove(tbHocVien);

                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    return BadRequest("Lỗi vi phạm ràng buộc khóa ngoại xảy ra khi bạn cố gắng xóa hoặc cập nhật một bản ghi trong bảng mà các bảng khác đang tham chiếu đến thông qua khóa ngoại ");
                }
            }

            private bool TbHocVienExists(int id)
            {
                return _context.TbHocViens.Any(e => e.IdHocVien == id);
            }
            private async Task<bool> existId(string id)
            {
                //Kiểm tra đã tồn tại trong TbKyLuatCanBo chua
                TbHocVien? cr = (await _context.TbHocViens.SingleOrDefaultAsync(e => e.MaHocVien == id));
                if (cr == null) return false;
                return true;
            }
        }
    }
