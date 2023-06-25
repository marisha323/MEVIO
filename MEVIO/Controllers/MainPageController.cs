using MEVIO.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using System.Text.Json;

namespace MEVIO.Controllers
{
    public class MainPageController : Controller
    {
        public MEVIOContext context;
        public MainPageController(MEVIOContext db)
        {
            this.context = db;
         


        }
        public async Task <IActionResult> MainPage()
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
            ViewBag.Tasks = context.Tasks.ToList();
            ViewBag.MeasureUsers= context.MeasuresUsers.ToList();
            ViewBag.UserAccept=context.UserAcceptStatuses.ToList();
            ViewBag.Measures=context.Measures.ToList();
            ViewBag.TaskUsers = context.TasksUsers.ToList();
            ViewBag.Eventes = context.Events.ToList();
            ViewBag.EventsUsers= context.EventsUsers.ToList();

            /*var BeginD = context.Events.AsNoTracking().ToList().Begin;
            ViewBag.BeginD = BeginD.ToString("yyyy-MM-dd");
            var EndD = context.Events.FirstOrDefault().End;
            ViewBag.EndD = EndD.ToString("yyyy-MM-dd");
            var LastTimeD = context.Users.FirstOrDefault().LastTimeSignIn;
            ViewBag.LastTimeD = LastTimeD.ToString("yyyy-MM-dd");*/




            return View();
        }



        
    }
}
