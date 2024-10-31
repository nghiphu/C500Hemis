﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using C500Hemis.Models;


namespace C500Hemis.Controllers.KHCN
{
    public class TaiSanTriTueController : Controller
    {
        private readonly HemisContext _context;
        private readonly ILogger<TaiSanTriTueController> _logger;

        // Constructor duy nhất nhận tất cả các tham số cần thiết
        public TaiSanTriTueController(HemisContext context, ILogger<TaiSanTriTueController> logger)
        {
            _context = context;
            _logger = logger;
            _logger.LogInformation("Controler TaiSanTriTue Đang chạy");
        }
       

        // GET: TaiSanTriTue
        // Cập nhật phương thức Index trong controller
        public async Task<IActionResult> Index()
        {
            try
            {
                var hemisContext = _context.TbTaiSanTriTues
                        .Include(t => t.IdLoaiTaiSanTriTueNavigation)
                        .Include(t => t.IdNhiemVuKhcnNavigation);
                var records = hemisContext.ToList(); // Lấy danh sách bản ghi
                ViewBag.RecordCount = records.Count; // Đếm số bản ghi


                return View(await hemisContext.ToListAsync());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching data for Index view");
                return BadRequest(new { message = "Đã xảy ra lỗi khi lấy dữ liệu. Vui lòng thử lại sau." });
            }
        }

<<<<<<< Updated upstream
        // GET: TaiSanTriTue
        //Search
        [HttpGet]
        [Route("TaiSanTriTue/Index/{id?}")]
        public async Task<IActionResult> Index(int? id) // Phương thức Index, trả về IActionResult và nhận tham số id tùy chọn  
        {
            try // Bắt đầu khối try để xử lý ngoại lệ  
            {
                if (id == null) // Kiểm tra xem id có giá trị hay không  
                {
                    _logger.LogInformation("Fetching all TaiSanTriTue records."); // Ghi lại thông tin log khi lấy tất cả bản ghi  
                                                                                  // Truy vấn tất cả bản ghi trong bảng TbTaiSanTriTues và bao gồm các liên kết  
                    var hemisContext = _context.TbTaiSanTriTues
                        .Include(t => t.IdLoaiTaiSanTriTueNavigation) // Bao gồm thông tin loại tài sản trí tuệ  
                        .Include(t => t.IdNhiemVuKhcnNavigation); // Bao gồm thông tin nhiệm vụ KHCN  
                    return View(await hemisContext.ToListAsync()); // Trả về view với danh sách tất cả bản ghi  
                }

                // Tìm đối tượng theo Id  
                var tbTaiSanTriTue = await _context.TbTaiSanTriTues
                    .Include(t => t.IdLoaiTaiSanTriTueNavigation) // Bao gồm thông tin loại tài sản trí tuệ  
                    .Include(t => t.IdNhiemVuKhcnNavigation) // Bao gồm thông tin nhiệm vụ KHCN  
                    .FirstOrDefaultAsync(m => m.IdTaiSanTriTue == id); // Tìm bản ghi đầu tiên có Id giống với tham số id  

                if (tbTaiSanTriTue == null) // Nếu không tìm thấy bản ghi  
                {
                    _logger.LogWarning("TaiSanTriTue with ID {Id} not found.", id); // Ghi lại cảnh báo log  
                    ViewBag.NotFoundMessage = "Không tìm thấy tài sản trí tuệ với ID này."; // Thông điệp lỗi cho view  
                    var hemisContext = _context.TbTaiSanTriTues
                        .Include(t => t.IdLoaiTaiSanTriTueNavigation) // Bao gồm thông tin loại tài sản trí tuệ  
                        .Include(t => t.IdNhiemVuKhcnNavigation); // Bao gồm thông tin nhiệm vụ KHCN  
                    return View(await hemisContext.ToListAsync()); // Trả về view với danh sách tất cả bản ghi  
                }

                _logger.LogInformation("TaiSanTriTue with ID {Id} fetched successfully.", id); // Ghi lại log thành công  
                return View("Details", tbTaiSanTriTue); // Trả về view "Details" với bản ghi đã tìm thấy  
            }
            catch (DbUpdateException ex) // Bắt lỗi liên quan đến cập nhật cơ sở dữ liệu  
            {
                _logger.LogError(ex, "An error occurred while updating the database for TaiSanTriTue with ID {Id}", id); // Ghi lại lỗi log  
                return BadRequest(new { message = "Đã xảy ra lỗi khi cập nhật cơ sở dữ liệu. Vui lòng thử lại sau." }); // Trả về thông điệp lỗi  
            }
            catch (InvalidOperationException ex) // Bắt lỗi liên quan đến hoạt động không hợp lệ  
            {
                _logger.LogError(ex, "An invalid operation occurred for TaiSanTriTue with ID {Id}", id); // Ghi lại lỗi log  
                return BadRequest(new { message = "Đã xảy ra một thao tác không hợp lệ. Vui lòng thử lại sau." }); // Trả về thông điệp lỗi  
            }
            catch (Exception ex) // Bắt lỗi chung  
            {
                _logger.LogError(ex, "An error occurred while fetching data for TaiSanTriTue with ID {Id}", id); // Ghi lại lỗi log  
                return BadRequest(new { message = "Đã xảy ra lỗi khi lấy dữ liệu. Vui lòng thử lại sau." }); // Trả về thông điệp lỗi chung  
            }
        }
        // GET: TaiSanTriTue/Details/5

        public async Task<IActionResult> Details(int? id) // Phương thức Details, trả về IActionResult và nhận tham số id tùy chọn  
        {
            try // Bắt đầu khối try để xử lý ngoại lệ  
            {
                if (id == null) // Kiểm tra xem id có giá trị hay không  
                {
                    _logger.LogWarning("Details method called with null id"); // Ghi lại cảnh báo log khi id là null  
                    return NotFound(); // Trả về kết quả NotFound (404) nếu id là null  
                }

                // Tìm bản ghi theo Id  
                var tbTaiSanTriTue = await _context.TbTaiSanTriTues
                    .Include(t => t.IdLoaiTaiSanTriTueNavigation) // Bao gồm thông tin loại tài sản trí tuệ  
                    .Include(t => t.IdNhiemVuKhcnNavigation) // Bao gồm thông tin nhiệm vụ KHCN  
                    .FirstOrDefaultAsync(m => m.IdTaiSanTriTue == id); // Tìm bản ghi đầu tiên có Id giống với tham số id  

                if (tbTaiSanTriTue == null) // Nếu không tìm thấy bản ghi  
                {
                    _logger.LogWarning("TbTaiSanTriTue with ID {Id} not found.", id); // Ghi lại cảnh báo log  
                    return NotFound(); // Trả về kết quả NotFound (404) nếu không tìm thấy bản ghi  
                }

                return View(tbTaiSanTriTue); // Trả về view với bản ghi đã tìm thấy  
            }
            catch (ArgumentNullException ex) // Bắt lỗi khi một đối số bắt buộc bị truyền vào phương thức với giá trị null  
            {
                _logger.LogError(ex, "A required argument was null for TbTaiSanTriTue with ID {Id}", id); // Ghi lại lỗi log  
                return BadRequest(new { message = "Một tham số cần thiết đã được truyền vào giá trị null. Vui lòng thử lại." }); // Trả về thông điệp lỗi  
            }
            catch (TimeoutException ex) // Bắt lỗi khi một hoạt động kéo dài quá thời gian chờ được thiết lập  
            {
                _logger.LogError(ex, "A timeout occurred while fetching data for TbTaiSanTriTue with ID {Id}", id); // Ghi lại lỗi log  
                return BadRequest(new { message = "Yêu cầu đã hết thời gian chờ. Vui lòng thử lại sau." }); // Trả về thông điệp lỗi  
            }
            catch (Exception ex) // Bắt lỗi chung  
            {
                _logger.LogError(ex, "An error occurred while fetching Details for TbTaiSanTriTue with ID {Id}", id); // Ghi lại lỗi log  
                return BadRequest(new { message = "Đã xảy ra lỗi khi lấy dữ liệu. Vui lòng thử lại sau." }); // Trả về thông điệp lỗi chung  
=======
        // GET: Tài sản trí tuệ
        public async Task<IActionResult> Index(int? Search)
        {
            try
            {
                // Khởi tạo 1 truy vấn từ bảng TbTaiSanTriTues
                IQueryable<TbTaiSanTriTue> query = _context.TbTaiSanTriTues
                    .Include(t => t.IdLoaiTaiSanTriTueNavigation)
                    .Include(t => t.IdNhiemVuKhcnNavigation);

                // Nếu có giá trị tìm kiếm, lọc theo IdTaiSanTriTue
                if (Search.HasValue)
                {
                    query = query.Where(s => s.IdTaiSanTriTue == Search.Value);
                    // Điều kiện lọc theo IdTaiSanTriTue.
                }

                // Thực hiện truy vấn và lấy danh sách các bản ghi
                var result = await query.ToListAsync();

                return View(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Hình như có lỗi rồi!!!. Hãy thử lại nhé bạn.");
            }
        }


        // Xử lý yêu cầu xem chi tiết tài sản trí tuệ theo Id
        public async Task<IActionResult> Details(int? id)
        {
            // Kiểm tra nếu Id là null, trả về lỗi NotFound
            if (id == null)
            {
                return NotFound();
            }
            try
            {
                // Truy vấn cơ sở dữ liệu để lấy tài sản trí tuệ theo Id
                // Kết hợp bao gồm các thông tin liên quan từ bảng Loại Tài Sản Trí Tuệ và Nhiệm Vụ KHCN
                var tbTaiSanTriTue = await _context.TbTaiSanTriTues
                    .Include(t => t.IdLoaiTaiSanTriTueNavigation)
                    .Include(t => t.IdNhiemVuKhcnNavigation)
                    .FirstOrDefaultAsync(m => m.IdTaiSanTriTue == id);

                // Kiểm tra nếu tài sản trí tuệ không tồn tại, trả về lỗi NotFound
                if (tbTaiSanTriTue == null)
                {
                    return NotFound();
                }
                
                // Trả về View hiển thị chi tiết của tài sản trí tuệ
                return View(tbTaiSanTriTue);
            }
            catch (Exception ex)
            {
                // Trả về mã lỗi 500 cùng với thông báo lỗi tùy chỉnh nếu xảy ra ngoại lệ
                return StatusCode(500, "Hình như có lỗi rồi!!! Hãy thử lại nhé bạn.");
>>>>>>> Stashed changes
            }
        }

        // GET: Tạo mới tài sản trí tuệ
        public IActionResult Create()
        {
            try
            {
<<<<<<< Updated upstream
                // Lấy danh sách ID tài sản trí tuệ truyền cho selectbox cán bộ bên view
                //tham số 1 là table nguồn được chọn để lấy dữ liệu 
                //tham số thứ 2 đc chọn để submit lên server, tham số 3 để hiện droplist
                //tham số 4 là dữ liệu hiển thị mặc định trong
                ViewData["IdLoaiTaiSanTriTue"] = new SelectList(_context.DmLoaiTaiSanTriTues, "IdLoaiTaiSanTriTue", "LoaiTaiSanTriTue");
                ViewData["IdNhiemVuKhcn"] = new SelectList(_context.TbNhiemVuKhcns, "IdNhiemVuKhcn", "TenNhiemVu");
=======
                // Dropdown cho loại tài sản trí tuệ từ cơ sở dữ liệu
                ViewData["IdLoaiTaiSanTriTue"] = new SelectList(_context.DmLoaiTaiSanTriTues, "IdLoaiTaiSanTriTue", "LoaiTaiSanTriTue");

                // Dropdown cho nhiệm vụ khoa học công nghệ từ cơ sở dữ liệu
                ViewData["IdNhiemVuKhcn"] = new SelectList(_context.TbNhiemVuKhcns, "IdNhiemVuKhcn", "TenNhiemVu");

>>>>>>> Stashed changes
                return View();
            }
            catch (Exception ex)
            {
<<<<<<< Updated upstream
                _logger.LogError(ex, "An error occurred while preparing the Create view");
                return BadRequest(new { message = "Đã xảy ra lỗi khi chuẩn bị chế độ xem. Vui lòng thử lại sau." });
            }
        }


        // POST: TaiSanTriTue/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
=======
                // Nếu có lỗi, trả về mã trạng thái 500 với thông báo lỗi
                return StatusCode(500, "Hình như có lỗi rồi!! Hãy thử lại nhé.");
            }
        }

        // POST: Tạo mới tài sản trí tuệ
>>>>>>> Stashed changes
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTaiSanTriTue,IdNhiemVuKhcn,MaGiaiPhapSangChe,TenTaiSanTriTue,ToChucCapBangGiayChungNhan,IdLoaiTaiSanTriTue,NgayCapBangGiayChungNhan,ToChucCapBang,SoBang,NgayCap,SoDon,NgayNopDon,QuyetDinhCapBangGiayChungNhan,CongBoBang,Ipc,ChuSoHuu,TacGiaSangCheGiaiPhap,TomTatNoiDungTaiSanTriTue,NguoiChuTri,NamDuocChapNhanDonHopLe")] TbTaiSanTriTue tbTaiSanTriTue)
        {
            try
            {
<<<<<<< Updated upstream
                if (!ModelState.IsValid)
                {
                    // Nếu ModelState không hợp lệ, trả về View với thông tin đã nhập
                    PopulateDropDowns(tbTaiSanTriTue);
                    return View(tbTaiSanTriTue);
                }

                // Kiểm tra nếu IdTaiSanTriTue đã tồn tại
                bool idExists = await _context.TbTaiSanTriTues.AnyAsync(e => e.IdTaiSanTriTue == tbTaiSanTriTue.IdTaiSanTriTue);
                if (idExists)
                {
                    ModelState.AddModelError("IdTaiSanTriTue", "Id đã tồn tại. Vui lòng nhập Id khác.");
                    PopulateDropDowns(tbTaiSanTriTue);
                    return View(tbTaiSanTriTue);
                }

                // Thêm đối tượng vào ngữ cảnh
                _context.Add(tbTaiSanTriTue);
                await _context.SaveChangesAsync();


                return RedirectToAction(nameof(Index));

            }
            catch (DbUpdateException dbEx)
            {
                _logger.LogError(dbEx, "Database update error occurred while creating TbTaiSanTriTue");
                ModelState.AddModelError(string.Empty, "Có lỗi xảy ra khi lưu vào cơ sở dữ liệu. Vui lòng thử lại.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while creating TbTaiSanTriTue");
                ModelState.AddModelError(string.Empty, "Đã xảy ra lỗi không mong muốn. Vui lòng thử lại sau.");
            }

            // Nếu có lỗi, trả về View với thông tin đã nhập
            PopulateDropDowns(tbTaiSanTriTue);
            return View(tbTaiSanTriTue);
=======
                // Kiểm tra tính hợp lệ của mô hình
                if (ModelState.IsValid)
                {
                    // Thêm đối tượng tài sản trí tuệ vào ngữ cảnh
                    _context.Add(tbTaiSanTriTue);

                    // Lưu thay đổi vào cơ sở dữ liệu
                    await _context.SaveChangesAsync();

                    // Chuyển hướng đến trang chỉ mục
                    return RedirectToAction(nameof(Index));
                }
                // Cập nhật dropdown danh sách chọn cho loại tài sản trí tuệ
                ViewData["IdLoaiTaiSanTriTue"] = new SelectList(_context.DmLoaiTaiSanTriTues, "IdLoaiTaiSanTriTue", "LoaiTaiSanTriTue", tbTaiSanTriTue.IdLoaiTaiSanTriTue);

                // Cập nhật danh sách dropdown chọn cho loại tài sản trí tuệ
                ViewData["IdNhiemVuKhcn"] = new SelectList(_context.TbNhiemVuKhcns, "IdNhiemVuKhcn", "TenNhiemVu", tbTaiSanTriTue.IdNhiemVuKhcn);

                // Trả về view với đối tượng tài sản trí tuệ
                return View(tbTaiSanTriTue);
            }
            catch (Exception ex)
            {
                // Nếu có lỗi, trả về mã trạng thái 500 với thông báo lỗi
                return StatusCode(500, "Hình như có lỗi rồi!!!");
            }
>>>>>>> Stashed changes
        }
        private void PopulateDropDowns(TbTaiSanTriTue tbTaiSanTriTue)//update select list cho dropdow
        {
            ViewData["IdLoaiTaiSanTriTue"] = new SelectList(_context.DmLoaiTaiSanTriTues, "IdLoaiTaiSanTriTue", "LoaiTaiSanTriTue", tbTaiSanTriTue.IdLoaiTaiSanTriTue);
            ViewData["IdNhiemVuKhcn"] = new SelectList(_context.TbNhiemVuKhcns, "IdNhiemVuKhcn", "TenNhiemVu", tbTaiSanTriTue.IdNhiemVuKhcn);
        }

        // GET: Chỉnh sửa tài sản trí tuệ theo ID
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
<<<<<<< Updated upstream
                if (id == null)//kiểm tra Id có null không 
                {   //nêu id=null ghi lại lỗi trên logger và trả về notFound
                    _logger.LogWarning("Edit method called with null id");
                    return NotFound(new { message = "Không tìm thấy tài sản trí tuệ với ID này." });
                }

                var tbTaiSanTriTue = await _context.TbTaiSanTriTues.FindAsync(id);//tìm kiếm id trong Db

                if (tbTaiSanTriTue == null)//nếu Id ==null => không tồn tại trong Db => trả về notFound
                {
                    _logger.LogWarning("TbTaiSanTriTue with ID {Id} not found.", id);
                    return NotFound(new { message = "Không tìm thấy tài sản trí tuệ với ID này." });
                }

                ViewData["IdLoaiTaiSanTriTue"] = new SelectList(_context.DmLoaiTaiSanTriTues, "IdLoaiTaiSanTriTue", "LoaiTaiSanTriTue", tbTaiSanTriTue.IdLoaiTaiSanTriTue);
                ViewData["IdNhiemVuKhcn"] = new SelectList(_context.TbNhiemVuKhcns, "IdNhiemVuKhcn", "TenNhiemVu", tbTaiSanTriTue.IdNhiemVuKhcn);

=======
                // Kiểm tra xem ID có null không
                if (id == null)
                {
                    return NotFound();
                }

                // Tìm tài sản trí tuệ trong cơ sở dữ liệu theo ID
                var tbTaiSanTriTue = await _context.TbTaiSanTriTues.FindAsync(id);
                if (tbTaiSanTriTue == null)
                {
                    return NotFound();// Nếu không tìm thấy, trả về không tìm thấy
                }

                // Cập nhật danh sách chọn cho loại tài sản trí tuệ
                ViewData["IdLoaiTaiSanTriTue"] = new SelectList(_context.DmLoaiTaiSanTriTues, "IdLoaiTaiSanTriTue", "LoaiTaiSanTriTue", tbTaiSanTriTue.IdLoaiTaiSanTriTue);

                // Cập nhật danh sách chọn cho nhiệm vụ khoa học công nghệ
                ViewData["IdNhiemVuKhcn"] = new SelectList(_context.TbNhiemVuKhcns, "IdNhiemVuKhcn", "TenNhiemVu", tbTaiSanTriTue.IdNhiemVuKhcn);

                // Trả về view với đối tượng tài sản trí tuệ đã tìm thấy
>>>>>>> Stashed changes
                return View(tbTaiSanTriTue);
            }
            catch (Exception ex)
            {
<<<<<<< Updated upstream
                _logger.LogError(ex, "An error occurred while fetching data for Edit view with ID {Id}", id);
                return BadRequest(new { message = "Đã xảy ra lỗi khi chuẩn bị chế độ xem. Vui lòng thử lại sau." });
            }
        }


        // POST: TaiSanTriTue/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
=======
                return StatusCode(500, "Hình như có lỗi rồi");
            }
        }

        // POST: Chỉnh sửa tài sản trí tuệ theo ID
>>>>>>> Stashed changes
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTaiSanTriTue,IdNhiemVuKhcn,MaGiaiPhapSangChe,TenTaiSanTriTue,ToChucCapBangGiayChungNhan,IdLoaiTaiSanTriTue,NgayCapBangGiayChungNhan,ToChucCapBang,SoBang,NgayCap,SoDon,NgayNopDon,QuyetDinhCapBangGiayChungNhan,CongBoBang,Ipc,ChuSoHuu,TacGiaSangCheGiaiPhap,TomTatNoiDungTaiSanTriTue,NguoiChuTri,NamDuocChapNhanDonHopLe")] TbTaiSanTriTue tbTaiSanTriTue)
        {
<<<<<<< Updated upstream
            if (id != tbTaiSanTriTue.IdTaiSanTriTue)//không tìm thấy Id => trả về notFound
=======
            // Kiểm tra xem ID có khớp với tài sản trí tuệ không
            if (id != tbTaiSanTriTue.IdTaiSanTriTue)
>>>>>>> Stashed changes
            {
                return NotFound(); // Nếu không khớp, trả về không tìm thấy
            }

<<<<<<< Updated upstream
            if (ModelState.IsValid)//kiểm tra dữ liệu nhập vào có hợp lệ hay không
=======
            // Kiểm tra tính hợp lệ của mô hình
            if (ModelState.IsValid)
>>>>>>> Stashed changes
            {
                try
                {
                    // Cập nhật tài sản trí tuệ trong ngữ cảnh
                    _context.Update(tbTaiSanTriTue);
                    // Lưu thay đổi vào cơ sở dữ liệu
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    // Kiểm tra xem tài sản trí tuệ còn tồn tại hay không
                    if (!TbTaiSanTriTueExists(tbTaiSanTriTue.IdTaiSanTriTue))
                    {
                        return NotFound(); // Nếu không tồn tại, trả về không tìm thấy
                    }
                    else
                    {
                        throw; // Nếu có lỗi khác, ném lại lỗi
                    }
                }
<<<<<<< Updated upstream
                return RedirectToAction(nameof(Index));//chuyển hướng đến Index nếu thành công
            }
            ViewData["IdLoaiTaiSanTriTue"] = new SelectList(_context.DmLoaiTaiSanTriTues, "IdLoaiTaiSanTriTue", "LoaiTaiSanTriTue", tbTaiSanTriTue.IdLoaiTaiSanTriTue);
            ViewData["IdNhiemVuKhcn"] = new SelectList(_context.TbNhiemVuKhcns, "IdNhiemVuKhcn", "TenNhiemVu", tbTaiSanTriTue.IdNhiemVuKhcn);
=======
                // Chuyển hướng đến trang chỉ mục
                return RedirectToAction(nameof(Index));
            }

            // Cập nhật danh sách chọn cho loại tài sản trí tuệ
            ViewData["IdLoaiTaiSanTriTue"] = new SelectList(_context.DmLoaiTaiSanTriTues, "IdLoaiTaiSanTriTue", "LoaiTaiSanTriTue", tbTaiSanTriTue.IdLoaiTaiSanTriTue);
            // Cập nhật danh sách chọn cho nhiệm vụ khoa học công nghệ
            ViewData["IdNhiemVuKhcn"] = new SelectList(_context.TbNhiemVuKhcns, "IdNhiemVuKhcn", "TenNhiemVu", tbTaiSanTriTue.IdNhiemVuKhcn);

            // Trả về view với đối tượng tài sản trí tuệ đã chỉnh sửa
>>>>>>> Stashed changes
            return View(tbTaiSanTriTue);
        }


        // GET: Xóa tài sản trí tuệ theo ID
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
<<<<<<< Updated upstream
                if (id == null)
                {   //ghi lỗi vào logger
                    _logger.LogWarning("Delete method called with null id");
                    return NotFound(new { message = "ID không hợp lệ." });
                }

                var tbTaiSanTriTue = await _context.TbTaiSanTriTues
                    .Include(t => t.IdLoaiTaiSanTriTueNavigation)
                    .Include(t => t.IdNhiemVuKhcnNavigation)
                    .FirstOrDefaultAsync(m => m.IdTaiSanTriTue == id);

                if (tbTaiSanTriTue == null)
                {
                    _logger.LogWarning("TbTaiSanTriTue with ID {Id} not found.", id);
                    return NotFound(new { message = "Không tìm thấy tài sản trí tuệ với ID này." });
                }
                TempData["ConfirmationMessage"] = "Bạn có chắc chắn muốn xóa tài sản này không?";
=======
                // Kiểm tra xem ID có null không
                if (id == null)
                {
                    return NotFound(); // Nếu null, trả về không tìm thấy
                }

                // Tìm tài sản trí tuệ trong cơ sở dữ liệu theo ID, bao gồm các navigation properties
                var tbTaiSanTriTue = await _context.TbTaiSanTriTues
                    .Include(t => t.IdLoaiTaiSanTriTueNavigation) // Bao gồm thông tin loại tài sản trí tuệ
                    .Include(t => t.IdNhiemVuKhcnNavigation) // Bao gồm thông tin nhiệm vụ khoa học công nghệ
                    .FirstOrDefaultAsync(m => m.IdTaiSanTriTue == id); // Lấy tài sản trí tuệ theo ID

                // Kiểm tra xem tài sản trí tuệ có tồn tại không
                if (tbTaiSanTriTue == null)
                {
                    return NotFound(); // Nếu không tìm thấy, trả về không tìm thấy
                }

                // Trả về view với đối tượng tài sản trí tuệ để xác nhận xóa
>>>>>>> Stashed changes
                return View(tbTaiSanTriTue);
            }
            catch (Exception ex)
            {
<<<<<<< Updated upstream
                _logger.LogError(ex, "An error occurred while fetching data for Delete view with ID {Id}", id);
                return BadRequest(new { message = "Đã xảy ra lỗi khi xóa dữ liệu. Vui lòng thử lại sau." });
            }
        }


        // POST: TaiSanTriTue/Delete/5
        [HttpPost, ActionName("Delete")] // Đánh dấu phương thức này là một hành động POST dành cho hành động xóa  
        [ValidateAntiForgeryToken] // Kiểm tra token chống giả mạo để bảo vệ khỏi các cuộc tấn công CSRF  
        public async Task<IActionResult> DeleteConfirmed(int id) // Phương thức xóa, nhận tham số id của tài sản trí tuệ  
        {
            try // Bắt đầu khối try để xử lý ngoại lệ  
            {
                // Tìm tài sản trí tuệ theo Id  
                var tbTaiSanTriTue = await _context.TbTaiSanTriTues.FindAsync(id);

                if (tbTaiSanTriTue != null) // Nếu tìm thấy tài sản trí tuệ  
                {
                    _context.TbTaiSanTriTues.Remove(tbTaiSanTriTue); // Xóa tài sản trí tuệ khỏi DbContext  
                    await _context.SaveChangesAsync(); // Lưu thay đổi vào cơ sở dữ liệu  

                    // Ghi lại log nếu xóa thành công  
                    _logger.LogInformation("TbTaiSanTriTue with ID {Id} was deleted successfully.", id);
                }
                else // Nếu không tìm thấy tài sản trí tuệ  
                {
                    _logger.LogWarning("TbTaiSanTriTue with ID {Id} not found.", id); // Ghi lại log cảnh báo  
                    return NotFound(new { message = "Không tìm thấy tài sản trí tuệ với ID này." }); // Trả về kết quả NotFound (404) kèm theo thông điệp  
                }

                return RedirectToAction(nameof(Index)); // Điều hướng tới hành động Index sau khi xóa thành công  
            }
            catch (Exception ex) // Bắt lỗi chung  
            {
                // Ghi lại log lỗi  
                _logger.LogError(ex, "An error occurred while deleting TbTaiSanTriTue with ID {Id}", id);
                return BadRequest(new { message = "Đã xảy ra lỗi khi xóa dữ liệu. Vui lòng thử lại sau." }); // Trả về thông điệp lỗi  
            }
=======
                // Nếu có lỗi, trả về mã trạng thái 500 với thông báo lỗi
                return StatusCode(500, "Hình như có lỗi rồi!!!");
            }
        }


        // Xử lý yêu cầu xóa tài sản trí tuệ với Id xác định
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                // Tìm kiếm tài sản trí tuệ theo Id trong cơ sở dữ liệu
                var tbTaiSanTriTue = await _context.TbTaiSanTriTues.FindAsync(id);
                
                // Nếu tài sản trí tuệ tồn tại, tiến hành xóa khỏi cơ sở dữ liệu
                if (tbTaiSanTriTue != null)
                {
                    _context.TbTaiSanTriTues.Remove(tbTaiSanTriTue);
                }

                await _context.SaveChangesAsync();

                // Chuyển hướng về trang danh sách tài sản trí tuệ
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Chuyển hướng đến trang hiển thị lỗi nếu có ngoại lệ xảy ra
                return RedirectToAction("Lỗi");
            }

>>>>>>> Stashed changes
        }


        // Phương thức kiểm tra sự tồn tại của một tài sản trí tuệ trong cơ sở dữ liệu dựa trên Id
        private bool TbTaiSanTriTueExists(int id)
        {
            return _context.TbTaiSanTriTues.Any(e => e.IdTaiSanTriTue == id);
        }
    }
}
