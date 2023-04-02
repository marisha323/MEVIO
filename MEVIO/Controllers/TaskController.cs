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
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> AddTask(string TaskName, string Description)
        {
           

           Tasks task = new Tasks
            {
                TaskName = TaskName,
                Description = Description,
               
                
            };

            if (task != null)
            {

                context.Tasks.Add(task);
                context.SaveChanges();

            }

            return Redirect("/Home/Index");
        }
    }
}
