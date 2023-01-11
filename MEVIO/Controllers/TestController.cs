using Microsoft.AspNetCore.Mvc;

namespace MEVIO.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
