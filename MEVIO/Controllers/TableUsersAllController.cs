using Microsoft.AspNetCore.Mvc;

namespace MEVIO.Controllers
{
    public class TableUsersAllController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
