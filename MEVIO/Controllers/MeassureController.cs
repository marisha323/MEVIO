using Microsoft.AspNetCore.Mvc;
using MEVIO.Models;

namespace MEVIO.Controllers
{
    public class MeassureController : Controller
    {

        MEVIOContext context;

        public MeassureController(MEVIOContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            ViewBag.Place=context.PlaceForMeasures.ToList();
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddMeasure([Bind("Id,MeasureName,Description,UserId,Begin,End")] Event event1)
        // public async Task<ActionResult> AddEvent(string title)
        {
            //var data = context.Events.FirstOrDefault().Begin;
            //ViewBag.Date = data.ToString("yyyy-MM-dd");
            //var dataEnd = context.Events.FirstOrDefault().Begin;
            //ViewBag.DateEnd = dataEnd.ToString("yyyy-MM-dd");
            if (event1 != null)
            {
                context.Events.Add(event1);
                context.SaveChanges();

            }

            return Redirect("/Home/Index");
        }
    }
}
