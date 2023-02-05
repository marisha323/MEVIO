using Microsoft.AspNetCore.Mvc;

namespace MEVIO.Controllers
{
    public class StudentContractController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
