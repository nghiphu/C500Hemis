// Controllers/CB/UserController.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HemisApi.Models;


namespace HemisApi.Controllers.CB
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DbHemisC500Context _context;

        public UserController(DbHemisC500Context context)
        {
            _context = context;
        }

        // GET: api/user
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbUser>>> GetTbUsers()
        {
            return await _context.TbUsers.ToListAsync();
        }

        // GET: api/user/{id}/idphong
        [HttpGet("{id}/idphong")]
        public async Task<ActionResult<int>> GetPhong(int id)
        {
            var tbUser = await _context.TbUsers.FindAsync(id);

            if (tbUser == null)
            {
                return NotFound(new { message = "Người dùng không tồn tại." });
            }

            return Ok(new { idPhong = tbUser.IdPhong });
        }

        // GET: api/user/{id}/idnguoi
        [HttpGet("{id}/idnguoi")]
        public async Task<ActionResult<int>> GetIdNguoi(int id)
        {
            var tbUser = await _context.TbUsers.FindAsync(id);

            if (tbUser == null)
            {
                return NotFound(new { message = "Người dùng không tồn tại." });
            }

            return Ok(new { idNguoi = tbUser.IdNguoi });
        }

        // GET: api/user/{id}/hoten
        [HttpGet("{id}/username")]
        public async Task<ActionResult<string>> GetUserName(int id)
        {
            var tbUser = await _context.TbUsers.FindAsync(id);

            if (tbUser == null)
            {
                return NotFound(new { message = "Người dùng không tồn tại." });
            }

            return Ok(new { username = tbUser.Username });
        }

        // POST: api/user/register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            if (model == null || string.IsNullOrEmpty(model.Username) || string.IsNullOrEmpty(model.Password))
            {
                return BadRequest(new { success = 0, message = "Thông tin đăng ký không hợp lệ." });
            }

            // Kiểm tra xem username đã tồn tại chưa
            var existingUser = await _context.TbUsers.FirstOrDefaultAsync(u => u.Username == model.Username);
            if (existingUser != null)
            {
                return BadRequest(new { success = 0, message = "Username đã tồn tại. Vui lòng chọn username khác." });
            }

            var newUser = new TbUser
            {
                Username = model.Username,
                Password = model.Password,
                IdPhong = model.IdPhong // Giả sử bạn có IdPhong trong RegisterModel
            };

            _context.TbUsers.Add(newUser);
            await _context.SaveChangesAsync();

            return Ok(new { success = 1, message = "Đăng ký thành công." });
        }

        // POST: api/user/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (model == null || string.IsNullOrEmpty(model.Username) || string.IsNullOrEmpty(model.Password))
            {
                return BadRequest(new { success = 0, message = "Thông tin đăng nhập không hợp lệ." });
            }

            var user = await _context.TbUsers.FirstOrDefaultAsync(u => u.Username == model.Username);
            if (user != null && model.Password==user.Password)
            {
                // 1: Đăng nhập thành công
                // Bạn có thể thêm token JWT hoặc session tại đây nếu muốn
                return Ok(new { success = 1, message = "Đăng nhập thành công." , idUser = user.IdNguoi});
            }

            // 0: Đăng nhập thất bại
            return Ok(new { success = 0, message = "Đăng nhập thất bại. Vui lòng kiểm tra lại thông tin." });
        }

        // DELETE: api/user/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var tbUser = await _context.TbUsers.FindAsync(id);
            if (tbUser == null)
            {
                return NotFound(new { message = "Người dùng không tồn tại." });
            }

            _context.TbUsers.Remove(tbUser);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
    public class RegisterModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int IdPhong { get; set; } // Thêm thuộc tính này nếu cần thiết
    }

    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
