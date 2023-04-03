using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Office2010.Excel;
using MEVIO.Models;
using Microsoft.AspNetCore.Mvc;

using System.Data.Entity;
using System.Text.Json;

namespace MEVIO.Controllers
{
    public class MyProfileController : Controller
    {
        public MEVIOContext context;
        public MyProfileController(MEVIOContext db)
        {
            this.context = db;
        }
        public IActionResult Index()
        {
            //ViewBag.Useres = context.Users.Where(o => o.Id == id).FirstOrDefault();
           
            User user = null;
            string UserLoggedIn = HttpContext.Request.Cookies["UserLoggedIn"];
            if (UserLoggedIn != null && UserLoggedIn != "")
            {
                user = JsonSerializer.Deserialize<User>(UserLoggedIn);
                ViewBag.Useres = context.Users.Where(o => o.Id == user.Id).FirstOrDefault();
            }
            return View();
        }
    }
}
