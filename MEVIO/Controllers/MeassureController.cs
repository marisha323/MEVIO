using Microsoft.AspNetCore.Mvc;
using MEVIO.Models;
using System.Text.Json;
using System.Globalization;
using MEVIO.Models.TelegramBot;
using Telegram.Bot;
using Telegram.Bot.Types;
using System.Data.Entity;

namespace MEVIO.Controllers
{
    public class MeassureController : Controller
    {

        MEVIOContext context;
        MEVIO.Models.User user1 = null;
        private readonly ITelegramBotClient botKey;
        public MeassureController(MEVIOContext context, ITelegramBotClient botClient)
        {
            this.context = context;
            botKey = botClient;

        }



        public async Task<IActionResult> Info()
        {
            return View();
        }


        public IActionResult Index()
        {
            MEVIO.Models.User user = null;
            string UserLoggedIn = HttpContext.Request.Cookies["UserLoggedIn"];
            ViewBag.CurrentDate = DateTime.Now.Date;
            if (UserLoggedIn != null && UserLoggedIn != "")
            {
                user = JsonSerializer.Deserialize<MEVIO.Models.User>(UserLoggedIn);
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
            try
            {
                //Get Id of create User
                string UserLoggedIn = HttpContext.Request.Cookies["UserLoggedIn"];
                user1 = JsonSerializer.Deserialize<MEVIO.Models.User>(UserLoggedIn);
                int userId = user1.Id;
                string creator = user1.UserName;

                //Get Place for Measure
                int placeId = int.Parse(Request.Form["placeSpend"]);
                var place = context.PlaceForMeasures.Where(o => o.Id == placeId).AsNoTracking().FirstOrDefault();



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
                    FreePlaces = FreePlaces,
                    PlaceForMeasureId = placeId,
                    UserId = userId,
                    Begin = dateTime1,
                    End = dateTime2
                };

                context.Measures.Add(measure);
                context.SaveChanges();

                // Last ID of Event
                var lastIdMeasure = context.Measures.ToList().LastOrDefault().Id;

                //All id of users
                var idsUser = Request.Form["userId"];


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


                var bot = HttpContext.RequestServices.GetRequiredService<TelegramBot>();
                measure.PlaceForMeasure = place;

                foreach (var item in idsUser)
                {
                    var userT = context.UserTelegram.Where(o => o.UserId == int.Parse(item)).FirstOrDefault();
                    await bot.SendMeasure(userT, measure, botKey, creator);
                }


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
            }
            catch(Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);

                return RedirectToAction("Index");
            }


            return Redirect("/Home/Index");
        }
    }
}
