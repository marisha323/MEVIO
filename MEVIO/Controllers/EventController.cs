using DocumentFormat.OpenXml.Bibliography;
using MEVIO.Models;
using MEVIO.Models.TelegramBot;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using System.Linq;
using System.Text.Json;
using Telegram.Bot;
using Telegram.Bot.Types;
namespace MEVIO.Controllers
{
    public class EventController : Controller
    {
        MEVIOContext context;
        MEVIO.Models.User user = null;
        private readonly ITelegramBotClient botKey;

        public EventController(MEVIOContext context,ITelegramBotClient botClient)
        {
            this.context = context;
            botKey = botClient;
        }

    ////[Authorize]
        public IActionResult Index()
        {
            //Current date
            ViewBag.CurrentDate =DateTime.Now.ToShortDateString();

            //create user from cookie
           
            string UserLoggedIn = HttpContext.Request.Cookies["UserLoggedIn"];


            if (UserLoggedIn != null && UserLoggedIn != "")
            {
                user = JsonSerializer.Deserialize<MEVIO.Models.User>(UserLoggedIn);
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
            ViewBag.Clients = context.Clients.ToList();   
                       
            ViewBag.UserAccept = context.UserAcceptStatuses.ToList();
                     
            return View();
        }


        [HttpPost]
       // public async Task<ActionResult> AddEvent([Bind("Id,EventName,Description,UserId,Begin,End")] Event event1)
        public async Task<ActionResult> AddEvent(/*int eventId,*/string EventName, string Description)
        {
            try
            {
                string dateField1 = Request.Form["dateField1"];
                string timeField1 = Request.Form["timeField1"];

                DateTime dateTime1 = DateTime.Parse(dateField1 + " " + timeField1);

                string dateField2 = Request.Form["dateField2"];
                string timeField2 = Request.Form["timeField2"];

                DateTime dateTime2 = DateTime.Parse(dateField2 + " " + timeField2);


                //Get Id of create User
                string UserLoggedIn = HttpContext.Request.Cookies["UserLoggedIn"];

                user = JsonSerializer.Deserialize<MEVIO.Models.User>(UserLoggedIn);

                int userId = user.Id;
                string creator = user.UserName;
                //Fill Event
                Event event1 = new Event()
                {
                    //Id= eventId,
                    UserId = userId,
                    EventName = EventName,
                    Description = Description,
                    Begin = dateTime1,
                    End = dateTime2
                };

                if (event1 != null)
                {
                    context.Events.Add(event1);
                    context.SaveChanges();
                }
                // Last ID of Event
                var lastIdEvent = context.Events.ToList().LastOrDefault().Id;

                //All id of users
                var idsUser = Request.Form["userId"];


                //var UserCheck = context.Users.Where(o => o.Id == idsUser).Select(p=>p.Id);

                foreach (var usersId in idsUser)
                {
                    var eventsUsers = new EventsUsers
                    {
                        EventId = lastIdEvent,
                        UserId = int.Parse(usersId),
                        IsCreator = false //устанавливаем false, поскольку это не создатель события
                    };
                    context.EventsUsers.Add(eventsUsers); //добавляем экземпляр EventsUsers в контекст базы данных
                }

                context.SaveChanges(); //сохраняем изменения в базе данных

                //sending message to the users
                //List<UserTelegram> userTelegrams = new List<UserTelegram>();
                // In the controller
                var bot = HttpContext.RequestServices.GetRequiredService<TelegramBot>();
                foreach (var item in idsUser)
                {
                    var userT = context.UserTelegram.Where(o => o.UserId == int.Parse(item)).AsNoTracking().FirstOrDefault();
                    await bot.SendEvent(userT, event1, botKey, creator);
                }

                // In the TelegramBot class
                //public async Task SendEvent(UserTelegram userTelegram, Event event1)
                //{
                //    Chat key = JsonSerializer.Deserialize<Chat>(userTelegram.TelegramJson);
                //    await botKey.SendTextMessageAsync(chatId: key, text: $"You got an upcoming Event!\nDescription: {event1.Description}\nBegin Time: {event1.Begin.ToString()}\nEnd Time: {event1.End.ToString()}\nCreator: {event1.User.UserName}");
                //}

                //Fill EventClients

                //All id of clients
                var idsClient = Request.Form["clientId"];

                foreach (var clientsId in idsClient)
                {
                    var eventsClients = new EventsClients
                    {
                        EventId = lastIdEvent,
                        ClientId = int.Parse(clientsId),
                        // IsCreator = false //устанавливаем false, поскольку это не создатель события
                    };
                    context.EventsClients.Add(eventsClients); //добавляем экземпляр EventsUsers в контекст базы данных
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
