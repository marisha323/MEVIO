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
            ViewBag.Place = context.PlaceForMeasures.ToList();
            ViewBag.Stud = context.Students.ToList();
            ViewBag.Users = context.Users.ToList();
            ViewBag.Meassure = context.Measures.ToList();
            ViewBag.MeassuresUsers = context.MeasuresUsers.ToList();


            ViewBag.Place=context.PlaceForMeasures.ToList();
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddMeasure([Bind("Id,MeasureName,Description,UserId,Begin,End")] Measure measure)
        {
            //var data = context.Events.FirstOrDefault().Begin;
            //ViewBag.Date = data.ToString("yyyy-MM-dd");
            //var dataEnd = context.Events.FirstOrDefault().Begin;
            //ViewBag.DateEnd = dataEnd.ToString("yyyy-MM-dd");
            if (measure != null)
            {
                context.Measures.Add(measure);
                context.SaveChanges();

            }


            return Redirect("/Home/Index");
        }
    }
}
