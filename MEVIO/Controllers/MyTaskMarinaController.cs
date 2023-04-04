using Microsoft.AspNetCore.Mvc;

namespace MEVIO.Controllers
{
    public class MyTaskMarinaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
