using DocumentFormat.OpenXml.InkML;
using MEVIO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Controller;

namespace MEVIO.Controllers
{
    public class TableUsersAllController : Controller
    {
        public MEVIOContext context;

        public TableUsersAllController(MEVIOContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            /*ViewBag.Users = context.Users.ToList();
            ViewBag.EventUsers = context.EventsUsers.ToList();
            ViewBag.Events = context.Events.ToList();
            ViewBag.TaskUsers = context.TasksUsers.ToList();
            ViewBag.Tasks = context.Tasks.ToList();*/

            ViewBag.Clients = context.Clients.ToList();
            ViewBag.EventClient=context.EventsClients.ToList();
            ViewBag.Events = context.Events.ToList();
            ViewBag.TaskClient = context.TasksClients.ToList();
            ViewBag.Tasks=context.Tasks.ToList();
            ViewBag.MeasureClient = context.MeasuresClients.ToList();
            ViewBag.Measures = context.Measures.ToList();

            return View();
        }
    }
}
