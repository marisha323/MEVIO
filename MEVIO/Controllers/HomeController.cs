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
        public HomeController(MEVIOContext db)
        {
            //this.context = db;
            //UserRole roleadmin = new UserRole() { UserRoleName = "admin" };
            //UserRole roledirector = new UserRole() { UserRoleName = "director" };
            //UserRole rolemanager = new UserRole() { UserRoleName = "manager" };
            //UserRole roleuser = new UserRole() { UserRoleName = "user" };
            //context.UserRoles.Add(roleadmin);
            //context.UserRoles.Add(roledirector);
            //context.UserRoles.Add(rolemanager);
            //context.UserRoles.Add(roleuser);
            //context.SaveChanges();
        }
        
        public IActionResult Index()
        {


            return View();
        }
        public IActionResult IndexTest()
        {


            return View();
        }
        public IActionResult Calendar1()
        {

            return View();
        }
        public IActionResult Chat()
        {

            return View();
        }
        public IActionResult MainPage()
        {

            return View();
        }
        public IActionResult ZapStudent()
        {

            return View();
        }
        public IActionResult ZapTeacher()
        {

            return View();
        }
        [Authorize(Roles = "Admin")]
        public IActionResult TestingAuthorize()
        {
            return View();
        }
        public IActionResult LoginRegister()
        {
            return View();
        }
        public IActionResult Event()
        {
            return View();
        }

        public IActionResult EventMini()
        {
            return View();
        }
        public IActionResult Measure()
        {
            return View();
        }
        [HttpPost]
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

        //        //var role = await context.Roles.FindAsync(user.UserRoleId);
        //        //var claims = new List<Claim>
        //        //{
        //        //    new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserName),
        //        //    new Claim(ClaimsIdentity.DefaultRoleClaimType,role!.UserRoleName)
        //        //};
        //        //var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
        //        //var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
        //        //await HttpContext.SignInAsync(claimsPrincipal);
        //        //return RedirectToAction("Index", "Home");
        //    }
        //    else
        //    {
        //        return View("LoginRegister");
        //    }
        //}
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Calendar()
        {
            return View();
        }
        string token = "5898521490:AAExzqnbIo-xFBea-Ad26XSvlX8xlxzb96U";
        static TelegramBotClient client;
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
        public async Task<IActionResult> SendMessage(string text, string js)
        {
            //string userCookie = Request.Cookies["UserLoggedIn"];
            string userCookie = "{\"MessageId\":32,\"From\":{\"Id\":707556393,\"IsBot\":false,\"FirstName\":\"Egor\",\"LastName\":\"Belen\",\"Username\":\"RegorBelenkov\",\"LanguageCode\":\"en\",\"CanJoinGroups\":null,\"CanReadAllGroupMessages\":null,\"SupportsInlineQueries\":null},\"SenderChat\":null,\"Date\":\"2023-01-17T03:51:32Z\",\"Chat\":{\"Id\":707556393,\"Type\":0,\"Title\":null,\"Username\":\"RegorBelenkov\",\"FirstName\":\"Egor\",\"LastName\":\"Belen\",\"Photo\":null,\"Bio\":null,\"Description\":null,\"InviteLink\":null,\"PinnedMessage\":null,\"Permissions\":null,\"SlowModeDelay\":null,\"StickerSetName\":null,\"CanSetStickerSet\":null,\"LinkedChatId\":0,\"Location\":null},\"ForwardFrom\":null,\"ForwardFromChat\":null,\"ForwardFromMessageId\":0,\"ForwardSignature\":null,\"ForwardSenderName\":null,\"ForwardDate\":null,\"ReplyToMessage\":null,\"ViaBot\":null,\"EditDate\":null,\"MediaGroupId\":null,\"AuthorSignature\":null,\"Text\":\"/saveme\",\"Entities\":[{\"Type\":2,\"Offset\":0,\"Length\":7,\"Url\":null,\"User\":null,\"Language\":null}],\"EntityValues\":[\"/saveme\"],\"Animation\":null,\"Audio\":null,\"Document\":null,\"Photo\":null,\"Sticker\":null,\"Video\":null,\"VideoNote\":null,\"Voice\":null,\"Caption\":null,\"CaptionEntities\":null,\"CaptionEntityValues\":null,\"Contact\":null,\"Dice\":null,\"Game\":null,\"Poll\":null,\"Venue\":null,\"Location\":null,\"NewChatMembers\":null,\"LeftChatMember\":null,\"NewChatTitle\":null,\"NewChatPhoto\":null,\"DeleteChatPhoto\":false,\"GroupChatCreated\":false,\"SupergroupChatCreated\":false,\"ChannelChatCreated\":false,\"MessageAutoDeleteTimerChanged\":null,\"MigrateToChatId\":0,\"MigrateFromChatId\":0,\"PinnedMessage\":null,\"Invoice\":null,\"SuccessfulPayment\":null,\"ConnectedWebsite\":null,\"PassportData\":null,\"ProximityAlertTriggered\":null,\"VoiceChatScheduled\":null,\"VoiceChatStarted\":null,\"VoiceChatEnded\":null,\"VoiceChatParticipantsInvited\":null,\"ReplyMarkup\":null,\"Type\":1}";

            Message message = JsonSerializer.Deserialize<Message>(userCookie);
            client = new TelegramBotClient(token);
            client.StartReceiving();
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(text);
            await client.SendTextMessageAsync(message.Chat.Id, builder.ToString());

            return View("Calendar");
        }
        [HttpPost]
        public async Task<IActionResult> SendMessageCalendar(string Email, DateTime SetDate, string Subject)
        {
            string key = "";
            Random rand = new Random();
            key = $"{key}{rand.Next(100000, 999999)}";

            //Users tempUser = new Users() { FullName = FullName, Email = Email, Password = Password, PhoneNumber = PhoneNumber.ToString(), RoleId = 2 };
            //string str = JsonSerializer.Serialize(tempUser);

            var fromAddress = new MailAddress("robottester51@gmail.com", "Online Shop");
            var toAddress = new MailAddress(Email, "Someone");
            const string fromPassword = "iokkbczukalzztuv";
            const string subject = "Calendar Notification";
            string body = $"{Subject} Date: {SetDate.ToString()}";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                Timeout = 20000
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
            return View("Calendar");
        }
        private static async void Client_OnCallBackQuery(object sender, Telegram.Bot.Args.CallbackQueryEventArgs e)
        {
            CallbackQuery callback = e.CallbackQuery;
            if (callback.Data == "Choice 2")
            {
                await client.SendTextMessageAsync(callback.Message.Chat.Id, "Correct choice");
            }
        }
        private async void Client_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            Message message = e.Message;
            if (message == null || message.Type != MessageType.Text)
            {
                return;
            }
            if (message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
            {
                string command = message.Text.Split(" ").First();
                switch (command)
                {
                    case "/help":
                        await SendHelp(message);
                        break;
                    case "/find":
                        await SendLocation(message);
                        break;
                    case "/goods":
                        await SendReplyButtons(message);
                        break;
                    case "/addme":
                        AddMe(message);
                        break;
                    default:
                        await client.SendTextMessageAsync(message.Chat.Id, $"{message.Text} was received {DateTime.Now}");
                        break;
                }
            }
            else
            {
                if (message.Type == MessageType.Location)
                {
                    await client.SendTextMessageAsync(message.Chat.Id, $"{message.Location.Latitude}  {message.Location.Longitude}");
                }
            }
        }
        private async Task AddMe(Message message)
        {
            string jsonMessage = JsonSerializer.Serialize(message);
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddMinutes(5);
            options.IsEssential = true;
            options.Path = "/";
            options.Secure = true;
            HttpContext.Response.Cookies.Append("UserLoggedIn", "hello", options);

            StringBuilder builder = new StringBuilder();
            string fullname = $"{message.From.FirstName} {message.From.LastName}";
            builder.AppendLine($"You are added to the messenger {fullname}!");
            await client.SendTextMessageAsync(message.Chat.Id, builder.ToString());
        }
        private static async Task SendHelp(Message message)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Bot`s commands:");
            builder.AppendLine("/help  -  list of commands");
            builder.AppendLine("/find  -  seek location");
            builder.AppendLine("/goods  -  list of goods");
            builder.AppendLine("/choice  -  list of choices");
            builder.AppendLine("/addme  -  Save yourself to Cookie!");

            await client.SendTextMessageAsync(message.Chat.Id, builder.ToString());
        }
        private static async Task SendReplyButtons(Message message)
        {
            ReplyKeyboardMarkup replyKeyboard = new ReplyKeyboardMarkup(
            new KeyboardButton[][]
            {
                new KeyboardButton[]{"Pizza","Sushi"},
                new KeyboardButton[]{"Pay","Delivery"},
            }, resizeKeyboard: true, oneTimeKeyboard: true);
            await client.SendTextMessageAsync(message.Chat.Id, "Make your choice:", replyMarkup: replyKeyboard);
        }
        private static async Task SendLocation(Message message)
        {
            ReplyKeyboardMarkup replyKeyboard = new ReplyKeyboardMarkup(
            new KeyboardButton[]{KeyboardButton.WithRequestContact("Contacts"),
            KeyboardButton.WithRequestLocation("Position") },
            resizeKeyboard: true, oneTimeKeyboard: true);
            await client.SendTextMessageAsync(message.Chat.Id, "Send data about yourself:",
                replyMarkup: replyKeyboard);
        }
        private static async Task SetInlineButtons(Message message)
        {
            InlineKeyboardMarkup inlineKeyboard = new InlineKeyboardMarkup
            (
                new InlineKeyboardButton[]
                {
                    InlineKeyboardButton.WithCallbackData("Choice 1"),
                    InlineKeyboardButton.WithCallbackData("Choice 2")
                });
            await client.SendTextMessageAsync(message.Chat.Id, "Make your choice: ",
              replyMarkup: inlineKeyboard);
        }
    }
}