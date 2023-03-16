using MEVIO.Models;
using Microsoft.AspNetCore.Mvc;

namespace MEVIO.Controllers
{
    public class TableUsersController : Controller
    {
        public MEVIOContext context;

        public TableUsersController(MEVIOContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            ViewBag.Users=context.Users.ToList();
            return View();
        }
    }
}
