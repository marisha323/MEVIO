using Microsoft.AspNetCore.Mvc;

namespace MEVIO.Controllers
{
    public class RegistryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
