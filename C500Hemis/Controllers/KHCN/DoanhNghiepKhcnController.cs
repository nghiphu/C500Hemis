using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using C500Hemis.Models;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

namespace C500Hemis.Controllers.KHCN
{public class DoanhNghiepKhcnController : Controller  
{  
    private readonly HemisContext _context; // Biến để lưu đối tượng context của cơ sở dữ liệu  
    private readonly ILogger<DoanhNghiepKhcnController> _logger; // Biến để ghi lại các thông điệp log  

    // Constructor cho controller, nhận vào context và logger  
    public DoanhNghiepKhcnController(HemisContext context, ILogger<DoanhNghiepKhcnController> logger)  
    {  
        _context = context; // Khởi tạo context  
        _logger = logger; // Khởi tạo logger  
    }  

    // GET: DoanhNghiepKhcn  
    public async Task<IActionResult> Index()  
    {  
        try  
        {  
            // Lấy tất cả các đối tượng DoanhNghiepKhcn từ cơ sở dữ liệu với bao gồm thông tin hình thức doanh nghiệp  
            var hemisContext = _context.TbDoanhNghiepKhcns.Include(t => t.IdHinhThucDoanhNghiepKhcnNavigation);  
            return View(await hemisContext.ToListAsync()); // Trả về view với danh sách đối tượng  
        }  
        catch  
        {  
            // Ghi lại lỗi trong logger  
            _logger.LogError("An error occurred while fetching data for Index view");  
            return BadRequest(new { message = "Đã xảy ra lỗi khi tìm kiếm dữ liệu. Vui lòng thử lại sau." }); // Trả về thông báo lỗi  
        }  
    }  

    // GET: DoanhNghiepKhcn/Index/{id?} - Phương thức tìm kiếm theo ID  
    [HttpGet]  
    [Route("DoanhNghiepKhcn/Index/{id?}")]  
    public async Task<IActionResult> Index(int? id)  
    {  
        try  
        {  
            // Kiểm tra nếu ID là null  
            if (id == null)  
            {  
                _logger.LogInformation("Fetching all DoanhNghiepKhcn records."); // Ghi lại thông tin về việc đang lấy tất cả bản ghi  
                var hemisContext = _context.TbDoanhNghiepKhcns  
                    .Include(t => t.IdHinhThucDoanhNghiepKhcnNavigation);  
                return View(await hemisContext.ToListAsync()); // Trả về view với danh sách đối tượng  
            }  

            // Tìm kiếm đối tượng theo id  
            var tbDoanhNghiepKhcn = await _context.TbDoanhNghiepKhcns  
                .Include(t => t.IdHinhThucDoanhNghiepKhcnNavigation)  
                .FirstOrDefaultAsync(m => m.IdDoanhNghiepKhcn == id); // Tìm kiếm đối tượng theo ID  

            if (tbDoanhNghiepKhcn == null)  
            {  
                _logger.LogWarning("DoanhNghiepKhcn with ID {Id} not found.", id); // Ghi lại cảnh báo nếu không tìm thấy đối tượng  
                ViewBag.Find = $"Không có đối tượng nào có ID: {id}"; // Gửi thông điệp về việc không tìm thấy đối tượng  
                var hemisContext = _context.TbDoanhNghiepKhcns  
                    .Include(t => t.IdHinhThucDoanhNghiepKhcnNavigation);  
                return View(await hemisContext.ToListAsync()); // Trả về view với danh sách đối tượng  
            }  

            _logger.LogInformation("DoanhNghiepKhcn with ID {Id} fetched successfully.", id); // Ghi lại thông tin khi tìm thấy đối tượng  
            return View("Details", tbDoanhNghiepKhcn); // Trả về view chi tiết cho đối tượng tìm thấy  
        }  
        catch (Exception ex)  
        {  
            _logger.LogError(ex, "An error occurred while searching for DoanhNghiepKhcn with ID {Id}", id); // Ghi lại lỗi nếu có  
            return BadRequest(new { message = "Đã xảy ra lỗi khi tìm kiếm dữ liệu. Vui lòng thử lại sau." }); // Trả về thông báo lỗi  
        }  
    }  


        // GET: DoanhNghiepKhcn/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var tbDoanhNghiepKhcn = await _context.TbDoanhNghiepKhcns
                    .Include(t => t.IdHinhThucDoanhNghiepKhcnNavigation)
                    .FirstOrDefaultAsync(m => m.IdDoanhNghiepKhcn == id);

                if (tbDoanhNghiepKhcn == null)
                {
                    return NotFound();
                }

                return View(tbDoanhNghiepKhcn);
            }
            catch (Exception ex)
            {
                // Ghi log lỗi (nếu bạn có sử dụng thư viện logging)
                _logger.LogError(ex, "Error occurred while getting details for id {Id}", id);

                // Trả về một lỗi tùy chỉnh hoặc trang lỗi

                return BadRequest(new { Message = "Lỗi máy chủ nội bộ. Vui lòng thử lại sau." });
            }
        }
        // GET: DoanhNghiepKhcn/Create
        public IActionResult Create()
        {
            try
            {
                ViewData["IdHinhThucDoanhNghiepKhcn"] = new SelectList(_context.DmHinhThucDoanhNghiepKhcns, "IdHinhThucDoanhNghiepKhcn", "HinhThucDoanhNghiepKhcn");
                return View();
            }
            catch (Exception ex)
            {
                // Ghi log lỗi (nếu cần)
                // Log the error (if needed)
                _logger.LogError(ex, "An error occurred while preparing the Create view");
                return BadRequest(new { Message = "Đã xảy ra lỗi khi chuẩn bị chế độ xem. Vui lòng thử lại sau." });
            }
        }


        // POST: DoanhNghiepKhcn/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDoanhNghiepKhcn,MaDoanhNghiep,TenDoanhNghiep,IdHinhThucDoanhNghiepKhcn,DiaDiemThanhLap,QuyMoDauTu,KinhPhiGopVonTuTaiSanTriTue,TyLeGopVonCuaCsgddh")] TbDoanhNghiepKhcn tbDoanhNghiepKhcn)
        {
            try
            {
                if (ModelState.IsValid) // kiểm tra dữ liệu có hợp lệ không
                {
                    // Kiểm tra xem Id đã tồn tại chưa
                    var existingEntity = await _context.TbDoanhNghiepKhcns.FindAsync(tbDoanhNghiepKhcn.IdDoanhNghiepKhcn);
                    if (existingEntity != null)
                    {
                        // Nếu Id đã tồn tại, có thể trả về thông báo lỗi
                        ModelState.AddModelError("IdDoanhNghiepKhcn", "Id đã tồn tại.");
                        return View(tbDoanhNghiepKhcn);
                    }
                    else
                    {
                        //add dữ liệu vào
                        _context.Add(tbDoanhNghiepKhcn);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }


                }
                //cập nhật lại  ViewData["IdHinhThucDoanhNghiepKhcn"]
                ViewData["IdHinhThucDoanhNghiepKhcn"] = new SelectList(_context.DmHinhThucDoanhNghiepKhcns, "IdHinhThucDoanhNghiepKhcn", "HinhThucDoanhNghiepKhcn", tbDoanhNghiepKhcn.IdHinhThucDoanhNghiepKhcn);
                return View(tbDoanhNghiepKhcn);
            }
            catch (Exception ex)
            {
                // Ghi lại lỗi
                _logger.LogError(ex, "An error occurred while creating TbTaiSanTriTue");
                // Trả về BadRequest với thông báo lỗi cụ thể
                return BadRequest(new { message = "Đã xảy ra lỗi khi cố gắng tạo bản ghi. Vui lòng thử lại sau." });
            }
        }


        // GET: DoanhNghiepKhcn/Edit/5
      public async Task<IActionResult> Edit(int? id)  
{  
    try  
    {  
        if (id == null) // Kiểm tra ID có null không  
        {  
            return NotFound();  
        }  

        var tbDoanhNghiepKhcn = await _context.TbDoanhNghiepKhcns.FindAsync(id); // Tìm kiếm đối tượng theo ID  
        if (tbDoanhNghiepKhcn == null) // Nếu đối tượng = null => không có đối tượng => NotFound  
        {  
            return NotFound();  
        }  

        // Cập nhật lại danh sách dropdown  
        ViewData["IdHinhThucDoanhNghiepKhcn"] = new SelectList(_context.DmHinhThucDoanhNghiepKhcns, "IdHinhThucDoanhNghiepKhcn", "HinhThucDoanhNghiepKhcn", tbDoanhNghiepKhcn.IdHinhThucDoanhNghiepKhcn);  
        return View(tbDoanhNghiepKhcn);  
    }  
    catch (Exception ex)  
    {  
        _logger.LogError(ex, "An unexpected error occurred.");  
        return BadRequest("Một lỗi bất ngờ đã xảy ra. Vui lòng thử lại sau.");  
    }  
}  

// POST: DoanhNghiepKhcn/Edit/5  
[HttpPost]  
[ValidateAntiForgeryToken]  
public async Task<IActionResult> Edit(int id, [Bind("IdDoanhNghiepKhcn,MaDoanhNghiep,TenDoanhNghiep,IdHinhThucDoanhNghiepKhcn,DiaDiemThanhLap,QuyMoDauTu,KinhPhiGopVonTuTaiSanTriTue,TyLeGopVonCuaCsgddh")] TbDoanhNghiepKhcn tbDoanhNghiepKhcn)  
{  
    if (id != tbDoanhNghiepKhcn.IdDoanhNghiepKhcn)  
    {  
        return NotFound();  
    }  

    if (ModelState.IsValid)  
    {  
        try  
        {  
            // Tìm bản ghi hiện tại trong cơ sở dữ liệu  
            var existingEntity = await _context.TbDoanhNghiepKhcns.FindAsync(id);  
            if (existingEntity == null)  
            {  
                return NotFound();  
            }  
            
            // Cập nhật các thuộc tính mà không thay đổi ID  
            existingEntity.MaDoanhNghiep = tbDoanhNghiepKhcn.MaDoanhNghiep;  
            existingEntity.TenDoanhNghiep = tbDoanhNghiepKhcn.TenDoanhNghiep;  
            existingEntity.IdHinhThucDoanhNghiepKhcn = tbDoanhNghiepKhcn.IdHinhThucDoanhNghiepKhcn;  
            existingEntity.DiaDiemThanhLap = tbDoanhNghiepKhcn.DiaDiemThanhLap;  
            existingEntity.QuyMoDauTu = tbDoanhNghiepKhcn.QuyMoDauTu;  
            existingEntity.KinhPhiGopVonTuTaiSanTriTue = tbDoanhNghiepKhcn.KinhPhiGopVonTuTaiSanTriTue;  
            existingEntity.TyLeGopVonCuaCsgddh = tbDoanhNghiepKhcn.TyLeGopVonCuaCsgddh;  

            // Cập nhật đối tượng đã tồn tại  
            _context.Update(existingEntity);  
            await _context.SaveChangesAsync();  
        }  
        catch (DbUpdateConcurrencyException ex) // Xung đột cập nhật dữ liệu  
        {  
            _logger.LogError(ex, "A concurrency error occurred while updating TbDoanhNghiepKhcn with ID {Id}", tbDoanhNghiepKhcn.IdDoanhNghiepKhcn);  
            if (!TbDoanhNghiepKhcnExists(tbDoanhNghiepKhcn.IdDoanhNghiepKhcn))  
            {  
                return NotFound();  
            }  
            else  
            {  
                throw;  
            }  
        }  
        catch (DbUpdateException ex) // Lỗi trong quá trình cập nhật cơ sở dữ liệu  
        {  
            _logger.LogError(ex, "A database update error occurred while updating TbDoanhNghiepKhcn with ID {Id}", tbDoanhNghiepKhcn.IdDoanhNghiepKhcn);  
            return BadRequest("Một lỗi cập nhật cơ sở dữ liệu đã xảy ra. Vui lòng thử lại sau.");  
        }  
        catch (Exception ex) // Lỗi bất kỳ  
        {  
            _logger.LogError(ex, "An unexpected error occurred while updating TbDoanhNghiepKhcn with ID {Id}", tbDoanhNghiepKhcn.IdDoanhNghiepKhcn);  
            return BadRequest("Một lỗi bất ngờ đã xảy ra. Vui lòng thử lại sau.");  
        }  

        return RedirectToAction(nameof(Index)); // Chuyển hướng về Index nếu thành công  
    }  

    // Cập nhật lại danh sách dropdown nếu ModelState không hợp lệ  
    ViewData["IdHinhThucDoanhNghiepKhcn"] = new SelectList(_context.DmHinhThucDoanhNghiepKhcns, "IdHinhThucDoanhNghiepKhcn", "HinhThucDoanhNghiepKhcn", tbDoanhNghiepKhcn.IdHinhThucDoanhNghiepKhcn);  
    return View(tbDoanhNghiepKhcn); // Trả về view nếu Model không hợp lệ  
}  



        // GET: DoanhNghiepKhcn/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    _logger.LogWarning("Delete operation attempted with null ID.");
                    return NotFound();
                }

                var tbDoanhNghiepKhcn = await _context.TbDoanhNghiepKhcns
                    .Include(t => t.IdHinhThucDoanhNghiepKhcnNavigation)
                    .FirstOrDefaultAsync(m => m.IdDoanhNghiepKhcn == id);

                if (tbDoanhNghiepKhcn == null)
                {
                    _logger.LogWarning("TbDoanhNghiepKhcn with ID {Id} not found.", id);
                    return NotFound();
                }

                return View(tbDoanhNghiepKhcn);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while trying to delete TbDoanhNghiepKhcn with ID {Id}.", id);
                return BadRequest("Đã xảy ra lỗi khi cố gắng xóa bản ghi. Vui lòng thử lại sau.");
            }
        }


        // POST: DoanhNghiepKhcn/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var tbDoanhNghiepKhcn = await _context.TbDoanhNghiepKhcns.FindAsync(id);
                if (tbDoanhNghiepKhcn != null)
                {
                    _context.TbDoanhNghiepKhcns.Remove(tbDoanhNghiepKhcn);
                    await _context.SaveChangesAsync();
                    _logger.LogInformation("TbDoanhNghiepKhcn with ID {Id} was deleted.", id);
                }
                else
                {
                    _logger.LogWarning("Attempted to delete TbDoanhNghiepKhcn with ID {Id} which does not exist.", id);
                    return NotFound();
                }

                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException ex)//Sinh ra khi có vấn đề xảy ra trong quá trình cập nhật hoặc xóa dữ liệu trong cơ sở dữ liệu.
            {
                _logger.LogError(ex, "A database update error occurred while deleting TbDoanhNghiepKhcn with ID {Id}.", id);
                return BadRequest("Đã xảy ra lỗi cập nhật cơ sở dữ liệu. Vui lòng thử lại sau.");
            }
            catch (Exception ex)//ngoại lệ chung 
            {
                _logger.LogError(ex, "An unexpected error occurred while deleting TbDoanhNghiepKhcn with ID {Id}.", id);
                return BadRequest("Một lỗi bất ngờ đã xảy ra. Vui lòng thử lại sau.");
            }
        }


        private bool TbDoanhNghiepKhcnExists(int id)
        {
            return _context.TbDoanhNghiepKhcns.Any(e => e.IdDoanhNghiepKhcn == id);
        }
    }
}
