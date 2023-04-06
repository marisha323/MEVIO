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

            if (eventChat == null)
            {
                context.EventsChat.Add(new()
                {
                    EventId = eventId,
                    EventChatName=Event.EventName
                });

                await context.SaveChangesAsync();
            }

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

            ViewBag.Messages = await context.ChatMessages.Where(m => m.EventChatId.Equals(eventChat.Id)).ToListAsync();


            return View("Index",user);
        }



        public async Task<IActionResult> GetTaskChat(int taskId)
        {
            User user = await GetAuthorizedUserAsync();

            if (user == null)
            {
                return Redirect("Registry/Index");
            }



            MEVIO.Models.Task Task = await context.Tasks.FirstOrDefaultAsync(e => e.Id.Equals(taskId));

            var taskChat = await context.TaskChats.FirstOrDefaultAsync(c => c.TaskId.Equals(taskId));

            if (taskChat == null)
            {
                context.TaskChats.Add(new()
                {
                    TaskId = taskId,
                    TaskChatName=Task.TaskName
                });

                await context.SaveChangesAsync();
            }

            var users = await context.TasksUsers.Where(e => e.TaskId.Equals(taskChat.TaskId)).ToListAsync();

            foreach (var item in users)
            {
                var tmpUser = await context.Users.FirstOrDefaultAsync(u => u.Id.Equals(item.UserId));

                taskChat.Users.Add(tmpUser);


            }


            ViewBag.ChatName = taskChat.TaskChatName;

            ViewBag.ChatId = taskChat.Id;

            ViewBag.ChatUsers = taskChat.Users;

            string date = $"{Task.Begin.ToShortDateString()} {Task.Begin.ToShortTimeString()} - {Task.End.ToShortDateString()} {Task.End.ToShortTimeString()}";

            ViewBag.Date = date;

            ViewBag.ChatType = "TaskChat";

            ViewBag.Messages = await context.ChatMessages.Where(m => m.TaskChatId.Equals(taskChat.Id)).ToListAsync();


            return View("Index", user);
        }



        public async Task<IActionResult> GetMeasureChat(int measureId)
        {
            User user = await GetAuthorizedUserAsync();

            if (user == null)
            {
                return Redirect("Registry/Index");
            }



            Measure Measure = await context.Measures.FirstOrDefaultAsync(e => e.Id.Equals(measureId));

            var measureChat = await context.MeasureChats.FirstOrDefaultAsync(c => c.MeasureId.Equals(measureId));

            if (measureChat == null)
            {
                context.MeasureChats.Add(new()
                {
                    MeasureId=measureId,
                    MeasureChatName=Measure.MeasureName
                });

                await context.SaveChangesAsync();
            }

            var users = await context.MeasuresUsers.Where(e => e.MeasureId.Equals(measureId)).ToListAsync();

            foreach (var item in users)
            {
                var tmpUser = await context.Users.FirstOrDefaultAsync(u => u.Id.Equals(item.UserId));

                measureChat.Users.Add(tmpUser);

            }


            ViewBag.ChatName = measureChat.MeasureChatName;

            ViewBag.ChatId = measureChat.Id;

            ViewBag.ChatUsers = measureChat.Users;

            string date = $"{Measure.Begin.ToShortDateString()} {Measure.Begin.ToShortTimeString()} - {Measure.End.ToShortDateString()} {Measure.End.ToShortTimeString()}";

            ViewBag.Date = date;

            ViewBag.ChatType = "MeasureChat";

            ViewBag.Messages = await context.ChatMessages.Where(m => m.MeasureChatId.Equals(measureChat.Id)).ToListAsync();


            return View("Index", user);
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






        public async Task<IActionResult> GetAllMessages(string chatType,int chatId)
        {

            List<ChatMessage> list = new List<ChatMessage>();
            List<User> users = new List<User>();

            if (chatType.Equals("EventChat"))
            {
                list = await context.ChatMessages.Where(m => m.EventChatId.Equals(chatId)).ToListAsync();
            }



            if (chatType.Equals("MeasureChat"))
            {
                list = await context.ChatMessages.Where(m => m.MeasureChatId.Equals(chatId)).ToListAsync();
            }

            if (chatType.Equals("TaskChat"))
            {
                list = await context.ChatMessages.Where(m => m.TaskChatId.Equals(chatId)).ToListAsync();
            }

            if (chatType.Equals("UserChat"))
            {
                list = await context.ChatMessages.Where(m => m.UserChatId.Equals(chatId)).ToListAsync();
            }


            var userList = list.Select(m => m.UserId).Distinct().ToList();


            foreach (var item in userList)
            {
                var tmpUser = await context.Users.FirstOrDefaultAsync(u => u.Id.Equals(item));

                users.Add(tmpUser!);

            }


            return Json(new { list = list, users = users });
        }
    }
}
