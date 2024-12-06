using Microsoft.AspNetCore.Mvc;
using C500Hemis.Models;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace C500Hemis.Controllers
{
    public class AccountController : Controller
    {
        // Đổi sang HTTP để test
        private readonly string _apiBaseUrl = "http://localhost:5224/api/user";

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var jsonData = JsonSerializer.Serialize(model);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            // Vì dùng HTTP nên không cần handler đặc biệt
            using (var client = new HttpClient())
            {
                var response = await client.PostAsync($"{_apiBaseUrl}/register", content);
                if (response.IsSuccessStatusCode)
                {
                    TempData["Message"] = "Đăng ký thành công, hãy đăng nhập.";
                    return RedirectToAction("Login");
                }
                else
                {
                    ViewBag.Error = "Đăng ký không thành công. Kiểm tra lại thông tin.";
                    return View(model);
                }
            }
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var jsonData = JsonSerializer.Serialize(model);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                var response = await client.PostAsync($"{_apiBaseUrl}/login", content);
                var responseBody = await response.Content.ReadAsStringAsync();

                using (var doc = JsonDocument.Parse(responseBody))
                {
                    var root = doc.RootElement;
                    int success = root.GetProperty("success").GetInt32();
                    string message = root.GetProperty("message").GetString();

                    if (success == 1)
                    {
                        int idUser = root.TryGetProperty("idUser", out var idUserProp) ? idUserProp.GetInt32() : 0;
                        HttpContext.Session.Set("UserId", System.BitConverter.GetBytes(idUser));
                        TempData["Message"] = message;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.Error = message;
                        return View(model);
                    }
                }
            }
        }
    }
}
