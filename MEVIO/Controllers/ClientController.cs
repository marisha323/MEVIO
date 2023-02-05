using Microsoft.AspNetCore.Mvc;

namespace MEVIO.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
