using MEVIO.Models;
using Microsoft.AspNetCore.Mvc;


namespace MEVIO.Controllers
{
    public class TaskController : Controller
    {
        MEVIOContext context;

        public TaskController(MEVIOContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var listUserId = context.TasksWatchingPersons.Select(o => o.UserId).ToList();

            var watchingPersonUserIds = context.TasksWatchingPersons
           .Where(twp => twp.UserId != null)
           .Select(twp => twp.UserId.Value)
           .Distinct();

            var watchingPersons = context.Users
             .Where(u => watchingPersonUserIds.Contains(u.Id))
             .ToList();

            ViewBag.WatchingPersons = watchingPersons;


            var responsiblePersonUserId = context.TaskResponsiblePersons.Where(rp => rp.UserId != null)
                .Select(rp => rp.UserId.Value)
                .Distinct();

            var responsiblePersons = context.Users.Where(u => responsiblePersonUserId.Contains(u.Id)).ToList();

            ViewBag.Resp = responsiblePersons;

            return View();
        }



        [HttpPost]
        public async Task<ActionResult> AddTask(string TaskName, string Description)
        {
           

            //Sasha

            //context.Tasks.Add(new()
            //{
            //    Description = Description,
            //    TaskName = TaskName
            //});

            //await context.SaveChangesAsync();

            return View();
        }
    }
}
