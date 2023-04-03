using MEVIO.Models;
using Mevio2Test.Helhers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Drawing;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace MEVIO.Controllers
{
    public class RegistryController : Controller
    {
        public MEVIOContext context;

        public RegistryController(MEVIOContext context)
        {

            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            User user = context.Users.Where(o => o.Email == email && o.Password == password).AsNoTracking().FirstOrDefault();
            if (user != null)
            {
                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.Now.AddDays(6);
                options.IsEssential = true;
                options.Path = "/";

                string str = JsonSerializer.Serialize(user);

                HttpContext.Response.Cookies.Append("UserLoggedIn", str, options);

               
                 return Redirect("/MainPage/MainPage");
               
            }
            else
            {
                return Redirect("Index");
            }

        }

        [Authorize]
        public async Task<IActionResult> MyProtectedAction()
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);

            // Перевірка, чи існує користувач в базі даних
            if (user == null)
            {
                return Forbid();
            }
            return View("/MainPage/MainPage");
            // Код захищеної дії
        }

        [HttpGet]
        public IActionResult Logout()
        {
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now;
            options.IsEssential = true;
            options.Path = "/";

            HttpContext.Response.Cookies.Append("UserLoggedIn", "", options);

            return Redirect("Index");
        }
    }
}

