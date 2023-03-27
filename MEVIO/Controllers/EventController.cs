using MEVIO.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace MEVIO.Controllers
{
    //[Authorize]
    public class EventController : Controller
    {
        MEVIOContext context;

        

        public EventController(MEVIOContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            User user = null;
            string UserLoggedIn = HttpContext.Request.Cookies["UserLoggedIn"];

            ViewBag.CurrentDate = DateTime.Now;

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
        public async Task<ActionResult> AddEvent([Bind("Id,EventName,Description,UserId,Begin,End")] Event event1)
       // public async Task<ActionResult> AddEvent(string title)
        {
            //DateTime begin = event1.Begin;
            //DateTime end = event1.End;

            //Sasha Alex
            //var ids = Request.Form["userId"];

            //DateTime begin = DateTime.Parse(event1.Begin);
            //DateTime end = DateTime.Parse(event1.End);

            if (event1 != null)
            {
               
                context.Events.Add(event1);
                context.SaveChanges();

            }




            return Redirect("/Home/Index");
        }

    }
}
