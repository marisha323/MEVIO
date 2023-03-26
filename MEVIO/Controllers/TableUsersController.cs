using MEVIO.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

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
            ViewBag.UserRoles=context.UserRoles.ToList();
            ViewBag.Students=context.Students.ToList();
            return View();
        }
    }
}
