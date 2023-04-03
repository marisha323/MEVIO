using MEVIO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace MEVIO.Controllers
{
    public class ChatController : Controller
    {
        MEVIOContext context;

        public ChatController(MEVIOContext context)
        {
            this.context = context;
        }



        private async Task<User> GetAuthorizedUserAsync()
        {
            string UserLoggedIn = HttpContext.Request.Cookies["UserLoggedIn"];


            if (UserLoggedIn == null && UserLoggedIn == "")
            {
                return null;
            }

            User user = JsonSerializer.Deserialize<User>(UserLoggedIn);



            return user;
        }



        public async Task<IActionResult> Index()
        {


            return Redirect("Registry/Index");
        }




        public async Task<IActionResult> GetEventChat(int eventId)
        {
            User user = await GetAuthorizedUserAsync();

            if (user == null)
            {
                return Redirect("Registry/Index");
            }



            Event Event = await context.Events.FirstOrDefaultAsync(e => e.Id.Equals(eventId));

            var eventChat = await context.EventsChat.FirstOrDefaultAsync(c => c.EventId.Equals(eventId));
            var users = await context.EventsUsers.Where(e => e.EventId.Equals(eventChat.EventId)).ToListAsync();

            foreach (var item in users)
            {
                var tmpUser = await context.Users.FirstOrDefaultAsync(u => u.Id.Equals(item.UserId));

                eventChat.Users.Add(tmpUser);


            }


            ViewBag.ChatName = eventChat.EventChatName;

            ViewBag.ChatId = eventChat.Id;

            ViewBag.ChatUsers = eventChat.Users;

            string date = $"{Event.Begin.ToShortDateString()} {Event.Begin.ToShortTimeString()} - {Event.End.ToShortDateString()} {Event.End.ToShortTimeString()}";

            ViewBag.Date = date;

            ViewBag.ChatType = "EventChat";



            return View("Index",user);
        }





        public async Task<IActionResult> AddNewMessage()
        {
            ChatMessage message = await Request.ReadFromJsonAsync<ChatMessage>();

            message.TimeStamp = DateTime.Now;

            context.ChatMessages.Add(message);

            await context.SaveChangesAsync();

            message.User = await context.Users.FirstOrDefaultAsync(u => u.Id.Equals(message.UserId));

            return Json(new { message = message, user = message.User });

        }



        public async Task<IActionResult> SendMessage()
        {



            return View("Index");
        }
    }
}
