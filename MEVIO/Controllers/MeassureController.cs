using Microsoft.AspNetCore.Mvc;
using MEVIO.Models;
using System.Text.Json;

namespace MEVIO.Controllers
{
    public class MeassureController : Controller
    {

        MEVIOContext context;

        public MeassureController(MEVIOContext context)
        {
            this.context = context;
        }



        public async Task<IActionResult> Info()
        {
            return View();
        }


        public IActionResult Index()
        {
            User user = null;
            string UserLoggedIn = HttpContext.Request.Cookies["UserLoggedIn"];
            ViewBag.CurrentDate = DateTime.Now.Date;
            if (UserLoggedIn != null && UserLoggedIn != "")
            {
                user = JsonSerializer.Deserialize<User>(UserLoggedIn);
                ViewBag.NameUser = user.UserName;
                //ViewBag.User = user;
                //ViewBag.Id = user.Id;
                //ViewBag.Role = user.UserRoleId;
                //ViewBag.NameUser = user.UserName;
                ViewBag.ImgPath = user.PathImgAVA;

            }

            ViewBag.Place = context.PlaceForMeasures.ToList();
            ViewBag.Stud = context.Students.ToList();
            ViewBag.Users = context.Users.ToList();
            ViewBag.Meassure = context.Measures.ToList();
            ViewBag.MeassuresUsers = context.MeasuresUsers.ToList();


            ViewBag.Place=context.PlaceForMeasures.ToList();
            return View();
        }

        [HttpPost]
        // public async Task<ActionResult> AddMeasure([Bind("Id,MeasureName,Description,UserId,Begin,End,FreePlaces")] Measure measure)
        public async Task<ActionResult> AddMeasure(string MeasureName,  int UserId,int FreePlaces )
        {
            string dateField1 = Request.Form["dateField1"];
            string timeField1 = Request.Form["timeField1"];

            DateTime dateTime1 = DateTime.Parse(dateField1 + " " + timeField1);

            string dateField2 = Request.Form["dateField2"];
            string timeField2 = Request.Form["timeField2"];

            DateTime dateTime2 = DateTime.Parse(dateField2 + " " + timeField2);

            Measure measure = new Measure
            {
                MeasureName = MeasureName,
                FreePlaces=FreePlaces,
                UserId = UserId,
                Begin = dateTime1,
                End = dateTime2
            };

            context.Measures.Add(measure);
                context.SaveChanges();

            


            return Redirect("/Home/Index");
        }
    }
}
