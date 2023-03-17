using MEVIO.Models;
using Mevio2Test.Helhers;
using Mevio2Test.Servises;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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
                options.Expires = DateTime.Now.AddMinutes(45);
                options.IsEssential = true;
                options.Path = "/";

                string str = JsonSerializer.Serialize(user);

                HttpContext.Response.Cookies.Append("UserLoggedIn", str, options);

               
                 return Redirect("/MainPage/MainPage");
                //return RedirectToAction("Index", "Main");
            }
            else
            {
                return Redirect("Index");
            }

        }

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

