using MEVIO.Models;
using Microsoft.AspNetCore.Mvc;

namespace MEVIO.Controllers
{
    public class EventController : Controller
    {
        MEVIOContext context;

        

        public EventController(MEVIOContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            ViewBag.Place = context.PlaceForMeasures.ToList();
            ViewBag.Stud = context.Students.ToList();
            ViewBag.Users = context.Users.ToList();
            ViewBag.Events = context.Events.ToList();
            ViewBag.EventsUsers = context.EventsUsers.ToList();
                 
                       
            ViewBag.UserAccept = context.UserAcceptStatuses.ToList();
                     
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> AddEvent([Bind("Id,EventName,Description,UserId,Begin,End")] Event event1)
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
