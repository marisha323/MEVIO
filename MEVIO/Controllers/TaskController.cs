using MEVIO.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Sockets;
using System.Text.Json;

namespace MEVIO.Controllers
{
    public class TaskController : Controller
    {
        MEVIOContext context;

        MEVIO.Models.User user = null;

        public TaskController(MEVIOContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
          
            ViewBag.Users=context.Users.ToList();

           // var watchingPersonUserIds = context.TasksWatchingPersons
           //.Where(twp => twp.UserId != null)
           //.Select(twp => twp.UserId.Value)
           //.Distinct();

           // var watchingPersons = context.Users
           //  .Where(u => watchingPersonUserIds.Contains(u.Id))
           //  .ToList();

           // ViewBag.WatchingPersons = watchingPersons;


           // var responsiblePersonUserId = context.TaskResponsiblePersons.Where(rp => rp.UserId != null)
           //     .Select(rp => rp.UserId.Value)
           //     .Distinct();

           // var responsiblePersons = context.Users.Where(u => responsiblePersonUserId.Contains(u.Id)).ToList();

           // ViewBag.Resp = responsiblePersons;

            return View();
        }



        [HttpPost]
        public async Task<ActionResult> AddTask(string TaskName, string Description)
        {
            try
            {
                //Get Id of create User
                string UserLoggedIn = HttpContext.Request.Cookies["UserLoggedIn"];

                user = JsonSerializer.Deserialize<MEVIO.Models.User>(UserLoggedIn);

                int userId = user.Id;
                string creator = user.UserName;

                //Get date & time
                string dateField1 = Request.Form["dateField1"];
                string timeField1 = Request.Form["timeField1"];

                DateTime dateTime1 = DateTime.Parse(dateField1 + " " + timeField1);

                string dateField2 = Request.Form["dateField2"];
                string timeField2 = Request.Form["timeField2"];

                DateTime dateTime2 = DateTime.Parse(dateField2 + " " + timeField2);


                //All Watching persons
                var idsWatchPersons = Request.Form["watchIdd"];

                //All Perponsible persons
                var idsResponsiblePersons = Request.Form["respIdd"];

                string underTaskName = Request.Form["underTask"];

                MEVIO.Models.Task task = new Models.Task
                {

                    TaskName = TaskName,
                    Description = Description,
                    IsImportant = true,
                    Begin = dateTime1,
                    End = dateTime2

                };

                if (task != null)
                {
                    context.Tasks.Add(task);
                    context.SaveChanges();
                }
                // Last ID of Task
                var lastIdTask = context.Tasks.ToList().LastOrDefault().Id;



                foreach (var clientsId in idsWatchPersons)
                {
                    var tasksWatchingPersons = new TasksWatchingPersons
                    {
                        TaskId = lastIdTask,
                        UserId = int.Parse(clientsId)

                    };
                    context.TasksWatchingPersons.Add(tasksWatchingPersons); //добавляем экземпляр EventsUsers в контекст базы данных
                }

                context.SaveChanges(); //сохраняем изменения в базе данных

                //////////////////////////////////////////
                foreach (var clientsId in idsResponsiblePersons)
                {
                    var tasksRespPersons = new TaskResponsiblePersons
                    {
                        TaskId = lastIdTask,
                        UserId = int.Parse(clientsId)

                    };
                    context.TaskResponsiblePersons.Add(tasksRespPersons); //добавляем экземпляр EventsUsers в контекст базы данных
                }

                context.SaveChanges(); //сохраняем изменения в базе данных


                UnderTask underTask = new UnderTask()
                {
                    TaskId = lastIdTask,
                    UnderTaskName = underTaskName

                };

                context.UnderTasks.Add(underTask);
                context.SaveChanges();


                //UserAcceptStatus userAcceptStatus = new UserAcceptStatus()
                //{


                //};
            }
            catch(Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return Redirect("/MyTaskMarina/Index");
            }


            return Redirect("/Home/Index");
        
        }
    }
}
