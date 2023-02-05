using Microsoft.AspNetCore.Mvc;

namespace MEVIO.Controllers
{
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
