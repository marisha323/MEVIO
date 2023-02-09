using Microsoft.AspNetCore.Mvc;

namespace MEVIO.Controllers
{
    public class UserActivityController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
