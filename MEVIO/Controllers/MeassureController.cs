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
               
            }

            ViewBag.Place = context.PlaceForMeasures.ToList();
            ViewBag.Stud = context.Students.ToList();
            ViewBag.Users = context.Users.ToList();
            ViewBag.Meassure = context.Measures.ToList();
            ViewBag.MeassuresUsers = context.MeasuresUsers.ToList();
            ViewBag.Clients = context.Clients.ToList();

            ViewBag.Place=context.PlaceForMeasures.ToList();
            return View();
        }

        [HttpPost]
        // public async Task<ActionResult> AddMeasure([Bind("Id,MeasureName,Description,UserId,Begin,End,FreePlaces")] Measure measure)
        public async Task<ActionResult> AddMeasure(string MeasureName,int UserId,int FreePlaces )
        {
            ////All id of users
            //var idsUser = Request.Form["userId"];
            ////All id of clients
            //var idsClient = Request.Form["clientId"];

            //DATETIME
            string dateField1 = Request.Form["dateField1"];
            string timeField1 = Request.Form["timeField1"];

            DateTime dateTime1 = DateTime.Parse(dateField1 + " " + timeField1);

            string dateField2 = Request.Form["dateField2"];
            string timeField2 = Request.Form["timeField2"];

            DateTime dateTime2 = DateTime.Parse(dateField2 + " " + timeField2);

            Measure measure = new Measure()
            {
                MeasureName = MeasureName,
                FreePlaces=FreePlaces,
                UserId = UserId,
                Begin = dateTime1,
                End = dateTime2
            };

            context.Measures.Add(measure);
            context.SaveChanges();



            // Last ID of Event
            var lastIdMeasure = context.Measures.ToList().LastOrDefault().Id;

            //All id of users
            var idsUser = Request.Form["userId"];


            //var UserCheck = context.Users.Where(o => o.Id == idsUser).Select(p=>p.Id);
            
            //Fill MeasureUsers
            foreach (var usersId in idsUser)
            {
                var measureUsers = new MeasureUsers
                {
                    MeasureId = lastIdMeasure,
                    UserId = int.Parse(usersId),
                    IsCreator = false //устанавливаем false, поскольку это не создатель события
                };
                context.MeasuresUsers.Add(measureUsers); //добавляем экземпляр MeasureUsers в контекст базы данных
            }

            context.SaveChanges(); //сохраняем изменения в базе данных


            //Fill MeasureClients

            //All id of clients
            var idsClient = Request.Form["clientId"];

            foreach (var clientsId in idsClient)
            {
                var measureClients = new MeasuresClients
                {
                    MeasureId = lastIdMeasure,
                    ClientId = int.Parse(clientsId),
                    // IsCreator = false //устанавливаем false, поскольку это не создатель события
                };
                context.MeasuresClients.Add(measureClients); //добавляем экземпляр EventsUsers в контекст базы данных
            }

            context.SaveChanges(); //сохраняем изменения в базе данных



            return Redirect("/Home/Index");
        }
    }
}
