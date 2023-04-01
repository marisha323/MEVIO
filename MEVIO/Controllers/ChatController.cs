using MEVIO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace MEVIO.Controllers
{
    public class ChatController : Controller
    {
        MEVIOContext context;

        public ChatController(MEVIOContext context)
        {
            this.context=context;
        }



        public async Task<IActionResult> Index(int eventId,int userId)
        {
            Console.WriteLine(eventId.ToString());
            Console.WriteLine(userId.ToString());

            User user = null;
            string UserLoggedIn = HttpContext.Request.Cookies["UserLoggedIn"];

            ViewBag.CurrentDate = DateTime.Now;

            if (UserLoggedIn != null && UserLoggedIn != "")
            {
                user = JsonSerializer.Deserialize<User>(UserLoggedIn);
                ViewBag.NameUser = user.UserName;
                //ViewBag.User = user;
                ViewBag.Id = user.Id;
                //ViewBag.Role = user.UserRoleId;
                //ViewBag.NameUser = user.UserName;
                //ViewBag.ImgPath = user.PathImgAVA;

            }

            var eventChat= await context.EventsChat.FirstOrDefaultAsync(c => c.EventId.Equals(eventId));
            var users = await context.EventsUsers.Where(e => e.EventId.Equals(eventChat.EventId)).ToListAsync();

            foreach (var item in users)
            {
                var tmpUser = await context.Users.FirstOrDefaultAsync(u => u.Id.Equals(item.UserId));

                eventChat.Users.Add(tmpUser);
            }

            

            ViewBag.Chat = eventChat;

            ViewBag.ChatUsers = eventChat.Users;

            Event Event = await context.Events.FirstOrDefaultAsync(e => e.Id.Equals(eventChat.EventId));

            string date = $"{Event.Begin.ToShortDateString()} {Event.Begin.ToShortTimeString()} - {Event.End.ToShortDateString()} {Event.End.ToShortTimeString()}";

            ViewBag.EventDate = date;

            ViewBag.ChatType = "EventChat";

            

            return View(user);
        }




        public async Task<IActionResult> SendMessage()
        {



            return View("Index");
        }
    }
}
