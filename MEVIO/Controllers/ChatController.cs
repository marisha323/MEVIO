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



        public async Task<IActionResult> Index(Object obj)
        {



            string UserLoggedIn = HttpContext.Request.Cookies["UserLoggedIn"];


            if (UserLoggedIn == null && UserLoggedIn == "")
            {
                return RedirectToAction("Registry/Index");
            }




            User user = JsonSerializer.Deserialize<User>(UserLoggedIn);
            ViewBag.NameUser = user.UserName;
            //ViewBag.User = user;
            ViewBag.Id = user.Id;
            //ViewBag.Role = user.UserRoleId;
            //ViewBag.NameUser = user.UserName;
            //ViewBag.ImgPath = user.PathImgAVA;





            if (obj.GetType() == typeof(Event))
            {
                Event Event = obj as Event;

                var eventChat = await context.EventsChat.FirstOrDefaultAsync(c => c.EventId.Equals(Event.Id));
                var users = await context.EventsUsers.Where(e => e.EventId.Equals(eventChat.EventId)).ToListAsync();

                foreach (var item in users)
                {
                    var tmpUser = await context.Users.FirstOrDefaultAsync(u => u.Id.Equals(item.UserId));

                    eventChat.Users.Add(tmpUser);


                }


                ViewBag.ChatName = eventChat.EventChatName;

                ViewBag.ChatUsers = eventChat.Users;

                string date = $"{Event.Begin.ToShortDateString()} {Event.Begin.ToShortTimeString()} - {Event.End.ToShortDateString()} {Event.End.ToShortTimeString()}";

                ViewBag.Date = date;

                ViewBag.ChatType = "EventChat";
            }









            //Event Event = await context.Events.FirstOrDefaultAsync(e => e.Id.Equals(eventChat.EventId));





            return View(user);
        }




        public async Task<IActionResult> GetEventChat(int eventId)
        {
            Event Event = await context.Events.FirstOrDefaultAsync(e => e.Id.Equals(eventId));

            return RedirectToAction("Index", new { obj = Event });
        }





        public async Task<IActionResult> AddNewMessage()
        {
            ChatMessage message = await Request.ReadFromJsonAsync<ChatMessage>();

            return Json(new { data = "ok" });
        }



        public async Task<IActionResult> SendMessage()
        {



            return View("Index");
        }
    }
}
