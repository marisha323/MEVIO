using MEVIO.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace MEVIO.Controllers
{
    public class EventController : Controller
    {
        MEVIOContext context;

        

        public EventController(MEVIOContext context)
        {
            this.context = context;
        }

    ////[Authorize]
        public IActionResult Index()
        {
            User user = null;
            string UserLoggedIn = HttpContext.Request.Cookies["UserLoggedIn"];

            ViewBag.CurrentDate =DateTime.Now.ToShortDateString();

            if (UserLoggedIn != null && UserLoggedIn != "")
            {
                user = JsonSerializer.Deserialize<User>(UserLoggedIn);
                ViewBag.NameUser=user.UserName;
                //ViewBag.User = user;
                ViewBag.Id = user.Id;
                //ViewBag.Role = user.UserRoleId;
                //ViewBag.NameUser = user.UserName;
                ViewBag.ImgPath = user.PathImgAVA;

            }

            //if (db.Users.AsNoTracking().Count() == 0)
            //{
            //    db.Roles.Add(new Roles() { Name = "Admin" });
            //    db.Roles.Add(new Roles() { Name = "User" });
            //    db.Users.Add(new Users() { FullName = "Admin", Email = "admin@gmail.com", Password = "12345", PhoneNumber = "0000", RoleId = 1 });
            //    db.SaveChanges();
            //}



            ViewBag.Place = context.PlaceForMeasures.ToList();
            ViewBag.Stud = context.Students.ToList();
            ViewBag.Users = context.Users.ToList();
            ViewBag.Events = context.Events.ToList();
            ViewBag.EventsUsers = context.EventsUsers.ToList();
                 
                       
            ViewBag.UserAccept = context.UserAcceptStatuses.ToList();
                     
            return View();
        }


        [HttpPost]
       // public async Task<ActionResult> AddEvent([Bind("Id,EventName,Description,UserId,Begin,End")] Event event1)
        public async Task<ActionResult> AddEvent(string EventName, string Description, int UserId)
        {
            string dateField1 = Request.Form["dateField1"];
            string timeField1 = Request.Form["timeField1"];

            DateTime dateTime1 = DateTime.Parse(dateField1 + " " + timeField1);

            string dateField2 = Request.Form["dateField2"];
            string timeField2 = Request.Form["timeField2"];

            DateTime dateTime2 = DateTime.Parse(dateField2 + " " + timeField2);

            Event event1 = new Event
            {
                EventName = EventName,
                Description = Description,
                UserId = UserId,
                Begin = dateTime1,
                End = dateTime2
            };
            

            //All id of users
            var ids = Request.Form["userId"];

            

            if (event1 != null)
            {
               
                context.Events.Add(event1);
                context.SaveChanges();

            }

            return Redirect("/Home/Index");
        }

    }
}
