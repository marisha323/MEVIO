using Microsoft.AspNetCore.Mvc;

namespace MEVIO.Controllers
{
    public class EventController : Controller
    { 
        public IActionResult Index()
        {
            return View();
        }
    }
}
