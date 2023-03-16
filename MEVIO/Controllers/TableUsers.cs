using Microsoft.AspNetCore.Mvc;

namespace MEVIO.Controllers
{
    public class TableUsers : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
