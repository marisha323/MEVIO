using Microsoft.AspNetCore.Mvc;

namespace MEVIO.Controllers
{
    public class TaskController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
