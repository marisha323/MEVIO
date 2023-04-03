using DocumentFormat.OpenXml.InkML;
using MEVIO.Models;
using Microsoft.AspNetCore.Mvc;

namespace MEVIO.Controllers
{
    public class TableUsersAllController : Controller
    {
        public MEVIOContext context;

        public TableUsersAllController(MEVIOContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            ViewBag.Users = context.Users.ToList();
            
            return View();
        }
    }
}
