using DocumentFormat.OpenXml.Bibliography;
using MEVIO.Models;
using Microsoft.AspNetCore.Mvc;

namespace MEVIO.Controllers
{
    public class MyTaskMarinaController : Controller
    {
        MEVIOContext context;

        public MyTaskMarinaController(MEVIOContext context)
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


            var responsiblePersonUserId=context.TaskResponsiblePersons.Where(rp=>rp.UserId != null)
                .Select(rp => rp.UserId.Value)
                .Distinct();

            var responsiblePersons = context.Users.Where(u => responsiblePersonUserId.Contains(u.Id)).ToList();

            ViewBag.Resp=responsiblePersons;

            return View();
        }
    }
}
