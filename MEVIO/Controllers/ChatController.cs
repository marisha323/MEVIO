using Microsoft.AspNetCore.Mvc;

namespace MEVIO.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
