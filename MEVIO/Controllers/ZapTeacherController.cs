using MEVIO.Models;
using Microsoft.AspNetCore.Mvc;

namespace MEVIO.Controllers
{
    public class ZapTeacherController : Controller
    {
        public MEVIOContext context;
        User user { get; set; }
        public ZapTeacherController(MEVIOContext db)
        {
            this.context = db;
        }
        public IActionResult Index()
        {
            /*context.Users.Add(user);
            await context.SaveChangesAsync();*/
            /* return View(context.Users.FirstOrDefault());*/
            return View();
        }
        public async Task<IActionResult> ZapTeacher([Bind] User user) {
            context.Users.Add(user);
            await context.SaveChangesAsync();
            return Redirect("/ZapTeacher/Index");
        }
    }

}
