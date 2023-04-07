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




        private async Task<List<UserChat>> GetUserChats(int userId)
        {
            List<UserChat> list = new List<UserChat>();

            var allUserChats = await context.UserChats.AsNoTracking().ToListAsync();
            var allUserChatUsers = await context.UserChatUsers.AsNoTracking().ToListAsync();
            var allUsers=await context.Users.AsNoTracking().ToListAsync();

            var chatsUser=await context.UserChatUsers.Where(c=>c.UserId.Equals(userId)).ToListAsync();

            foreach (var chat in chatsUser)
            {
                var Chat = allUserChats.FirstOrDefault(c => c.Id.Equals(chat.UserChatId));
                var userChatUser = allUserChatUsers.FirstOrDefault(c => c.UserChatId.Equals(chat.UserChatId) && c.UserId != userId);
                var user = allUsers.FirstOrDefault(u => u.Id.Equals(userChatUser.UserId));

                userChatUser.User = user;
                Chat.UserChatUsers.Add(userChatUser);

                list.Add(Chat);
            }


            return list.Reverse<UserChat>().ToList();
        }


        private async Task<List<EventChat>> GetEventChats(int userId)
        {
            List<EventChat> list = new List<EventChat>();


            var allEvents = await context.Events.AsNoTracking().ToListAsync();
            var allEventChats = await context.EventsChat.AsNoTracking().ToListAsync();

            var eventUsers = await context.EventsUsers.Where(e => e.UserId.Equals(userId)).ToListAsync();

            foreach (var eventUser in eventUsers)
            {
                var Event = allEvents.FirstOrDefault(e => e.Id.Equals(eventUser.EventId));
                var EventChat = allEventChats.FirstOrDefault(c => c.EventId.Equals(Event.Id));

                EventChat.Event = Event;
                list.Add(EventChat);
            }



            return list.Reverse<EventChat>().ToList();
        }


        private async Task<List<TaskChat>> GetTaskChats(int userId)
        {
            List<TaskChat> list = new List<TaskChat>();

            var allTasks=await context.Tasks.AsNoTracking().ToListAsync();
            var allTaskChats = await context.TaskChats.AsNoTracking().ToListAsync();

            var taskUsers = await context.TasksUsers.Where(t => t.UserId.Equals(userId)).ToListAsync();

            foreach (var item in taskUsers)
            {
                var Task = allTasks.FirstOrDefault(t => t.Id.Equals(item.TaskId));
                var TaskChat = allTaskChats.FirstOrDefault(t => t.TaskId.Equals(item.TaskId));

                TaskChat.Task = Task;
                list.Add(TaskChat);
            }



            return list.Reverse<TaskChat>().ToList();
        }


        private async Task<List<MeasureChat>> GetMeasureChats(int userId)
        {
            List<MeasureChat> list = new();


            var allMeasures=await context.Measures.ToListAsync();
            var allMeasureChats = await context.MeasureChats.ToListAsync();

            var measureUsers = await context.MeasuresUsers.Where(m => m.UserId.Equals(userId)).ToListAsync();

            foreach (var item in measureUsers)
            {
                var Measure = allMeasures.FirstOrDefault(m => m.Id.Equals(item.MeasureId));
                var MeasureChat = allMeasureChats.FirstOrDefault(c=>c.MeasureId.Equals(item.MeasureId));

                MeasureChat.Measure = Measure;
                list.Add(MeasureChat);
            }


            return list.Reverse<MeasureChat>().ToList();
        }





        public async Task<IActionResult> Index()
        {
            User user = await GetAuthorizedUserAsync();

            if (user == null)
            {
                return Redirect("Registry/Index");
            }


            ViewBag.ChatName = null;

            ViewBag.ChatId = null;

            ViewBag.ChatUsers = null;

            ViewBag.Date = null;

            ViewBag.ChatType = null;

            ViewBag.Messages = null;


            ViewBag.IsEmptyChat = true;



            ViewBag.UserChats = await GetUserChats(user.Id);

            ViewBag.EventChats = await GetEventChats(user.Id);

            ViewBag.TaskChats = await GetTaskChats(user.Id);

            ViewBag.MeasureChats = await GetMeasureChats(user.Id);


            return View(user);
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



            ViewBag.UserChats = await GetUserChats(user.Id);

            ViewBag.EventChats = await GetEventChats(user.Id);

            ViewBag.TaskChats = await GetTaskChats(user.Id);

            ViewBag.MeasureChats = await GetMeasureChats(user.Id);

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


            ViewBag.UserChats = await GetUserChats(user.Id);

            ViewBag.EventChats = await GetEventChats(user.Id);

            ViewBag.TaskChats = await GetTaskChats(user.Id);

            ViewBag.MeasureChats = await GetMeasureChats(user.Id);

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


            ViewBag.UserChats = await GetUserChats(user.Id);

            ViewBag.EventChats = await GetEventChats(user.Id);

            ViewBag.TaskChats = await GetTaskChats(user.Id);

            ViewBag.MeasureChats = await GetMeasureChats(user.Id);

            return View("Index", user);
        }



        public async Task<IActionResult> GetUserChat(int userId)
        {
            User user = await GetAuthorizedUserAsync();

            

            User? secondUser = await context.Users.FirstOrDefaultAsync(u => u.Id.Equals(userId));



            if (user == null)
            {
                return Redirect("Registry/Index");
            }



            UserChat? userChat = null;


            var allChats = await context.UserChatUsers.AsNoTracking().ToListAsync();

            var chatsBySecondUser = allChats.Where(c => c.UserId.Equals(secondUser.Id)).ToList();



            foreach (var chat in chatsBySecondUser)
            {
                var chats = allChats.Where(c => c.UserChatId.Equals(chat.UserChatId)).ToList();

                if (chats.Count>0)
                {
                    foreach (var tmp in chats)
                    {
                        if (tmp.UserId.Equals(user.Id))
                        {
                            userChat = await context.UserChats.FirstOrDefaultAsync(c => c.Id.Equals(tmp.UserChatId));
                            break;
                        }
                    }
                }
            }




            if (userChat == null)
            {
                userChat = new UserChat()
                {
                    UserChatName = $"{user.Id}-{secondUser.Id}"
                };

                context.UserChats.Add(userChat);

                context.SaveChanges();

                context.UserChatUsers.Add(new()
                {
                    UserChatId = userChat.Id,
                    UserId = user.Id
                });

                context.UserChatUsers.Add(new()
                {
                    UserChatId = userChat.Id,
                    UserId = secondUser.Id
                });


                await context.SaveChangesAsync();
            }



            



            ViewBag.ChatName = null;

            ViewBag.ChatId = userChat.Id;

            var list = new List<User>();
            list.Add(user);
            list.Add(secondUser);

            ViewBag.ChatUsers = list; 

            

            ViewBag.ChatType = "UserChat";

            ViewBag.Messages = await context.ChatMessages.Where(m => m.UserChatId.Equals(userChat.Id)).ToListAsync();

            ViewBag.SecondUser = secondUser;


            ViewBag.UserChats = await GetUserChats(user.Id);


            ViewBag.UserChats = await GetUserChats(user.Id);

            ViewBag.EventChats = await GetEventChats(user.Id);

            ViewBag.TaskChats = await GetTaskChats(user.Id);

            ViewBag.MeasureChats = await GetMeasureChats(user.Id);

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
