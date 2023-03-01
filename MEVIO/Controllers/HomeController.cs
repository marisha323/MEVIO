using MEVIO.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Mail;
using System.Net;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using System.Text;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.Extensions.Options;
using User = MEVIO.Models.User;
using Task = System.Threading.Tasks.Task;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace MEVIO.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public MEVIOContext context;

        List<User>users=new List<User>();

        public HomeController(MEVIOContext db)
        {
            this.context = db;
            UserRole roleadmin = new UserRole() { UserRoleName = "admin" };
            UserRole roledirector = new UserRole() { UserRoleName = "director" };
            UserRole rolemanager = new UserRole() { UserRoleName = "manager" };
            UserRole roleuser = new UserRole() { UserRoleName = "user" };
            context.Roles.Add(roleadmin);
            context.Roles.Add(roledirector);
            context.Roles.Add(rolemanager);
            context.Roles.Add(roleuser);
            context.SaveChanges();
        }
        

        
        public IActionResult Index()
        {
            AddUser();
            AddTask();
            AddTaskUsers();
            AddEvent();
            AddMeasure();
            AddMeasureUser();
            AddEventUser();
            AddDashBoard();
            //AddUserCalendar();
            //var users = context.Users.ToList();

            // var listTask=context.TasksUsers.Where(t=>)
            foreach (var user in users)
            {
              var tasks=context.TasksUsers.Where(t=>t.UserId==user.Id).ToList();
                foreach(var task in tasks)
                {
                    user.Tasks.Add(context.Tasks.FirstOrDefault(o => o.Id == task.TaskId));

                  //  Console.WriteLine(task.Id);
                }

            }

            ViewBag.Users = users;

         var users1=context.TasksUsers.Where(o=>o.TaskId==1).ToList();
         var users2=context.TasksUsers.Where(o=>o.TaskId==2).ToList();

            var Users1 = new List<User>();
            var Users2 = new List<User>();

            foreach(var user in users1)
            {
                Users1.Add(context.Users.FirstOrDefault(p=>p.Id.Equals(user.UserId)));
                
            }
            foreach (var user in users2)
            {
                Users2.Add(context.Users.FirstOrDefault(p => p.Id.Equals(user.UserId)));

            }
            ViewBag.Users1=Users1; ViewBag.Users2=Users2;

            //  var name = context.Users.Where(p => p.UserName).FirstOrDefault();
            return View(context);
        }

       
        private void AddEvent()
        {
            context.Events.Add(new Event() { UserId = 1, EventName = "EvName1", Description = "djfg", Begin = DateTime.Now, End = DateTime.Now });
            context.Events.Add(new Event() { UserId = 2, EventName = "EvName2", Description = "sweh", Begin = DateTime.Now, End = DateTime.Now });

            context.SaveChanges();
        }
        private void AddEventUser()
        {
            context.EventsUsers.Add(new EventsUsers { EventId=1, UserId = 1 });
            context.EventsUsers.Add(new EventsUsers { EventId=2, UserId = 2 });
            context.EventsUsers.Add(new EventsUsers { EventId = 1, UserId = 2 });
            context.EventsUsers.Add(new EventsUsers { EventId = 2, UserId =  3});
            context.SaveChanges();

        }

        //private void AddUserCalendar()
        //{
        //    context.UserCalendars.Add(new UserCalendar() { UserId = 4 });
        //    context.UserCalendars.Add(new UserCalendar() { UserId = 3 });
        //    context.UserCalendars.Add(new UserCalendar() { UserId = 2 });

        //    context.SaveChanges();
        //}
        private void AddMeasure()
        {
            context.Measures.Add(new Models.Measure() { MeasureName = "Measure1", UserId=1,  Begin = DateTime.Now, End = DateTime.Now, FreePlaces = 5 });
            context.Measures.Add(new Models.Measure() { MeasureName = "Measure2", UserId=2, Begin = DateTime.Now, End = DateTime.Now, FreePlaces = 7 });
            context.Measures.Add(new Models.Measure() { MeasureName = "Measure3", UserId=3, Begin = DateTime.Now, End = DateTime.Now, FreePlaces = 8 });
            context.Measures.Add(new Models.Measure() { MeasureName = "Measure4", UserId=3, Begin = DateTime.Now, End = DateTime.Now, FreePlaces = 5 });
            context.Measures.Add(new Models.Measure() { MeasureName = "Measure5", UserId=2,  Begin = DateTime.Now, End = DateTime.Now, FreePlaces = 22 });

            context.SaveChanges();
        }

        private void AddMeasureUser()
        {
            context.MeasuresUsers.Add(new MeasureUsers() { MeasureId = 1, UserId = 2 });
            context.MeasuresUsers.Add(new MeasureUsers() { MeasureId = 2, UserId = 3 });
            context.MeasuresUsers.Add(new MeasureUsers() { MeasureId = 3, UserId = 2 });
            context.MeasuresUsers.Add(new MeasureUsers() { MeasureId = 4, UserId = 3 });
            context.MeasuresUsers.Add(new MeasureUsers() { MeasureId = 5, UserId = 4 });

            context.SaveChanges();
        }

        private void AddDashBoard()
        {
            context.Dashboards.Add(new DashBoard() { UserId = 1 });
            context.Dashboards.Add(new DashBoard() { UserId = 2 });
            context.Dashboards.Add(new DashBoard() { UserId = 3 });
            context.Dashboards.Add(new DashBoard() { UserId = 4 });

            context.SaveChanges();
        }

        private void AddUser()
        {
            context.Users.Add(new User() { UserRoleId = 1, UserName = "Maria", DashBoardId=1 });
            context.Users.Add(new User() { UserRoleId = 2, UserName = "Max", DashBoardId = 2 });
            context.Users.Add(new User() { UserRoleId = 3, UserName = "Adrey", DashBoardId = 3});
            context.Users.Add(new User() { UserRoleId = 4, UserName = "Marina", DashBoardId = 4 });

            context.SaveChanges();
        }

        private void AddTask()
        {
            context.Tasks.Add(new Models.Task() { UserId = 1, TaskName = "task1", Begin = DateTime.Now, End = DateTime.Now, Description = "hjgfiwhg" });
            context.Tasks.Add(new Models.Task() { UserId = 2, TaskName = "task2", Begin = DateTime.Now, End = DateTime.Now, Description = "hjryeryiwhg" });
            context.Tasks.Add(new Models.Task() { UserId = 3, TaskName = "task3", Begin = DateTime.Now, End = DateTime.Now, Description = "hjryeryiwhg" });
            context.Tasks.Add(new Models.Task() { UserId = 4, TaskName = "task4", Begin = DateTime.Now, End = DateTime.Now, Description = "hjryeryiwhg" });
            context.Tasks.Add(new Models.Task() { UserId = 1, TaskName = "task5", Begin = DateTime.Now, End = DateTime.Now, Description = "hjryeryiwhg" });
            context.Tasks.Add(new Models.Task() { UserId = 2, TaskName = "task6", Begin = DateTime.Now, End = DateTime.Now, Description = "hjryeryiwhg" });


            context.SaveChanges();
        }



        private void AddTaskUsers()
        {
            context.TasksUsers.Add(new TasksUsers() { UserId = 1, TaskId= 1 });
            context.TasksUsers.Add(new TasksUsers() { UserId = 2, TaskId= 1 });
            context.TasksUsers.Add(new TasksUsers() { UserId = 1, TaskId= 5 });
            context.TasksUsers.Add(new TasksUsers() { UserId = 2, TaskId= 2 });
            context.TasksUsers.Add(new TasksUsers() { UserId = 4, TaskId= 4 });
            context.TasksUsers.Add(new TasksUsers() { UserId = 3, TaskId= 3 });

            context.TasksUsers.Add(new TasksUsers() { UserId = 1, TaskId = 2 });
            context.TasksUsers.Add(new TasksUsers() { UserId = 1, TaskId = 3 });
            context.TasksUsers.Add(new TasksUsers() { UserId = 1, TaskId = 4 });

            context.TasksUsers.Add(new TasksUsers() { UserId = 2, TaskId = 1 });
            context.TasksUsers.Add(new TasksUsers() { UserId = 2, TaskId = 2 });

            context.SaveChanges();
        }
        //[Authorize(Roles = "Admin")]
        //public IActionResult TestingAuthorize()
        //{
        //    return View();
        //}
        //public IActionResult LoginRegister()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public async Task<IActionResult> Login(string Email, string Password)
        //{
        //    var a = context.Users.AsNoTracking().ToList();
        //    User user = context.Users.Where(o => o.Email == Email && o.Password == Password).AsNoTracking().FirstOrDefault();
        //    if (user != null)
        //    {
        //        CookieOptions options = new CookieOptions();
        //        options.Expires = DateTime.Now.AddMinutes(45);
        //        options.IsEssential = true;
        //        options.Path = "/";

        //        string str = JsonSerializer.Serialize(user);

        //        HttpContext.Response.Cookies.Append("UserLoggedIn", str, options);

        //        var role = await context.Roles.FindAsync(user.UserRoleId);
        //        var claims = new List<Claim>
        //        {
        //            new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserName),
        //            new Claim(ClaimsIdentity.DefaultRoleClaimType,role!.UserRoleName)
        //        };
        //        var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
        //        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
        //        await HttpContext.SignInAsync(claimsPrincipal);
        //        return RedirectToAction("Index", "Home");
        //    }
        //    else
        //    {
        //        return View("LoginRegister");
        //    }
        //}
        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
        //public IActionResult Calendar()
        //{
        //    return View();
        //}
        //string token = "5898521490:AAExzqnbIo-xFBea-Ad26XSvlX8xlxzb96U";
        //static TelegramBotClient client;
        //public async Task<IActionResult> TestingBot()
        //{
        //    //client = new TelegramBotClient(token);
        //    //User user = client.GetMeAsync().Result;
        //    //ViewBag.User = user;

        //    //client.OnMessage += Client_OnMessage;
        //    //client.OnMessageEdited += Client_OnMessage;
        //    //client.OnCallbackQuery += Client_OnCallBackQuery;
        //    //client.StartReceiving();

        //    //return View("Calendar");
        //}
        //    public async Task<IActionResult> SendMessage(string text, string js)
        //    {
        //        //string userCookie = Request.Cookies["UserLoggedIn"];
        //        string userCookie = "{\"MessageId\":32,\"From\":{\"Id\":707556393,\"IsBot\":false,\"FirstName\":\"Egor\",\"LastName\":\"Belen\",\"Username\":\"RegorBelenkov\",\"LanguageCode\":\"en\",\"CanJoinGroups\":null,\"CanReadAllGroupMessages\":null,\"SupportsInlineQueries\":null},\"SenderChat\":null,\"Date\":\"2023-01-17T03:51:32Z\",\"Chat\":{\"Id\":707556393,\"Type\":0,\"Title\":null,\"Username\":\"RegorBelenkov\",\"FirstName\":\"Egor\",\"LastName\":\"Belen\",\"Photo\":null,\"Bio\":null,\"Description\":null,\"InviteLink\":null,\"PinnedMessage\":null,\"Permissions\":null,\"SlowModeDelay\":null,\"StickerSetName\":null,\"CanSetStickerSet\":null,\"LinkedChatId\":0,\"Location\":null},\"ForwardFrom\":null,\"ForwardFromChat\":null,\"ForwardFromMessageId\":0,\"ForwardSignature\":null,\"ForwardSenderName\":null,\"ForwardDate\":null,\"ReplyToMessage\":null,\"ViaBot\":null,\"EditDate\":null,\"MediaGroupId\":null,\"AuthorSignature\":null,\"Text\":\"/saveme\",\"Entities\":[{\"Type\":2,\"Offset\":0,\"Length\":7,\"Url\":null,\"User\":null,\"Language\":null}],\"EntityValues\":[\"/saveme\"],\"Animation\":null,\"Audio\":null,\"Document\":null,\"Photo\":null,\"Sticker\":null,\"Video\":null,\"VideoNote\":null,\"Voice\":null,\"Caption\":null,\"CaptionEntities\":null,\"CaptionEntityValues\":null,\"Contact\":null,\"Dice\":null,\"Game\":null,\"Poll\":null,\"Venue\":null,\"Location\":null,\"NewChatMembers\":null,\"LeftChatMember\":null,\"NewChatTitle\":null,\"NewChatPhoto\":null,\"DeleteChatPhoto\":false,\"GroupChatCreated\":false,\"SupergroupChatCreated\":false,\"ChannelChatCreated\":false,\"MessageAutoDeleteTimerChanged\":null,\"MigrateToChatId\":0,\"MigrateFromChatId\":0,\"PinnedMessage\":null,\"Invoice\":null,\"SuccessfulPayment\":null,\"ConnectedWebsite\":null,\"PassportData\":null,\"ProximityAlertTriggered\":null,\"VoiceChatScheduled\":null,\"VoiceChatStarted\":null,\"VoiceChatEnded\":null,\"VoiceChatParticipantsInvited\":null,\"ReplyMarkup\":null,\"Type\":1}";

        //        Message message = JsonSerializer.Deserialize<Message>(userCookie);
        //        client = new TelegramBotClient(token);
        //        client.StartReceiving();
        //        StringBuilder builder = new StringBuilder();
        //        builder.AppendLine(text);
        //        await client.SendTextMessageAsync(message.Chat.Id, builder.ToString());

        //        return View("Calendar");
        //    }
        //    [HttpPost]
        //    public async Task<IActionResult> SendMessageCalendar(string Email, DateTime SetDate, string Subject)
        //    {
        //        string key = "";
        //        Random rand = new Random();
        //        key = $"{key}{rand.Next(100000, 999999)}";

        //        //Users tempUser = new Users() { FullName = FullName, Email = Email, Password = Password, PhoneNumber = PhoneNumber.ToString(), RoleId = 2 };
        //        //string str = JsonSerializer.Serialize(tempUser);

        //        var fromAddress = new MailAddress("robottester51@gmail.com", "Online Shop");
        //        var toAddress = new MailAddress(Email, "Someone");
        //        const string fromPassword = "iokkbczukalzztuv";
        //        const string subject = "Calendar Notification";
        //        string body = $"{Subject} Date: {SetDate.ToString()}";

        //        var smtp = new SmtpClient
        //        {
        //            Host = "smtp.gmail.com",
        //            Port = 587,
        //            EnableSsl = true,
        //            DeliveryMethod = SmtpDeliveryMethod.Network,
        //            Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
        //            Timeout = 20000
        //        };
        //        using (var message = new MailMessage(fromAddress, toAddress)
        //        {
        //            Subject = subject,
        //            Body = body
        //        })
        //        {
        //            smtp.Send(message);
        //        }
        //        return View("Calendar");
        //    }
        //    private static async void Client_OnCallBackQuery(object sender, Telegram.Bot.Args.CallbackQueryEventArgs e)
        //    {
        //        CallbackQuery callback = e.CallbackQuery;
        //        if (callback.Data == "Choice 2")
        //        {
        //            await client.SendTextMessageAsync(callback.Message.Chat.Id, "Correct choice");
        //        }
        //    }
        //    private async void Client_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        //    {
        //        Message message = e.Message;
        //        if (message == null || message.Type != MessageType.Text)
        //        {
        //            return;
        //        }
        //        if (message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
        //        {
        //            string command = message.Text.Split(" ").First();
        //            switch (command)
        //            {
        //                case "/help":
        //                    await SendHelp(message);
        //                    break;
        //                case "/find":
        //                    await SendLocation(message);
        //                    break;
        //                case "/goods":
        //                    await SendReplyButtons(message);
        //                    break;
        //                case "/addme":
        //                    AddMe(message);
        //                    break;
        //                default:
        //                    await client.SendTextMessageAsync(message.Chat.Id, $"{message.Text} was received {DateTime.Now}");
        //                    break;
        //            }
        //        }
        //        else
        //        {
        //            if (message.Type == MessageType.Location)
        //            {
        //                await client.SendTextMessageAsync(message.Chat.Id, $"{message.Location.Latitude}  {message.Location.Longitude}");
        //            }
        //        }
        //    }
        //    private async Task AddMe(Message message)
        //    {
        //        string jsonMessage = JsonSerializer.Serialize(message);
        //        CookieOptions options = new CookieOptions();
        //        options.Expires = DateTime.Now.AddMinutes(5);
        //        options.IsEssential = true;
        //        options.Path = "/";
        //        options.Secure = true;
        //        HttpContext.Response.Cookies.Append("UserLoggedIn", "hello", options);

        //        StringBuilder builder = new StringBuilder();
        //        string fullname = $"{message.From.FirstName} {message.From.LastName}";
        //        builder.AppendLine($"You are added to the messenger {fullname}!");
        //        await client.SendTextMessageAsync(message.Chat.Id, builder.ToString());
        //    }
        //    private static async Task SendHelp(Message message)
        //    {
        //        StringBuilder builder = new StringBuilder();
        //        builder.AppendLine("Bot`s commands:");
        //        builder.AppendLine("/help  -  list of commands");
        //        builder.AppendLine("/find  -  seek location");
        //        builder.AppendLine("/goods  -  list of goods");
        //        builder.AppendLine("/choice  -  list of choices");
        //        builder.AppendLine("/addme  -  Save yourself to Cookie!");

        //        await client.SendTextMessageAsync(message.Chat.Id, builder.ToString());
        //    }
        //    private static async Task SendReplyButtons(Message message)
        //    {
        //        ReplyKeyboardMarkup replyKeyboard = new ReplyKeyboardMarkup(
        //        new KeyboardButton[][]
        //        {
        //            new KeyboardButton[]{"Pizza","Sushi"},
        //            new KeyboardButton[]{"Pay","Delivery"},
        //        }, resizeKeyboard: true, oneTimeKeyboard: true);
        //        await client.SendTextMessageAsync(message.Chat.Id, "Make your choice:", replyMarkup: replyKeyboard);
        //    }
        //    private static async Task SendLocation(Message message)
        //    {
        //        ReplyKeyboardMarkup replyKeyboard = new ReplyKeyboardMarkup(
        //        new KeyboardButton[]{KeyboardButton.WithRequestContact("Contacts"),
        //        KeyboardButton.WithRequestLocation("Position") },
        //        resizeKeyboard: true, oneTimeKeyboard: true);
        //        await client.SendTextMessageAsync(message.Chat.Id, "Send data about yourself:",
        //            replyMarkup: replyKeyboard);
        //    }
        //    private static async Task SetInlineButtons(Message message)
        //    {
        //        InlineKeyboardMarkup inlineKeyboard = new InlineKeyboardMarkup
        //        (
        //            new InlineKeyboardButton[]
        //            {
        //                InlineKeyboardButton.WithCallbackData("Choice 1"),
        //                InlineKeyboardButton.WithCallbackData("Choice 2")
        //            });
        //        await client.SendTextMessageAsync(message.Chat.Id, "Make your choice: ",
        //          replyMarkup: inlineKeyboard);
        //    }
    }
}