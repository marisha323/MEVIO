using MEVIO.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;

namespace MEVIO.Controllers
{
    public class MainPageController : Controller
    {
        public MEVIOContext context;
        public MainPageController(MEVIOContext db)
        {
            this.context = db;
         


        }
        public IActionResult MainPage()
        {
            
            ViewBag.Useres = context.Users.ToList();
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
