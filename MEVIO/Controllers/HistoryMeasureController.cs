using DocumentFormat.OpenXml.InkML;
using MEVIO.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace MEVIO.Controllers
{
    public class HistoryMeasureController : Controller
    {

        public MEVIOContext context;
        public HistoryMeasureController(MEVIOContext db)
        {
            this.context = db;



        }
        public IActionResult Index()
        {
            User user = null;
            string UserLoggedIn = HttpContext.Request.Cookies["UserLoggedIn"];
            if (UserLoggedIn != null && UserLoggedIn != "")
            {
                user = JsonSerializer.Deserialize<User>(UserLoggedIn);
                ViewBag.NameUser = user.UserName;
                ViewBag.UsersId = user.Id;
                ViewBag.CurrentRole = user.UserRoleId;
            }
            ViewBag.Useres = context.Users.ToList();
           
            ViewBag.MeasureUsers = context.MeasuresUsers.ToList();
            ViewBag.UserAccept = context.UserAcceptStatuses.ToList();
            ViewBag.Measures = context.Measures.ToList();
            ViewBag.Measures2 = context.Measures.Where(m => m.End < DateTime.Now).ToList();



            return View();
        }
    }
}
