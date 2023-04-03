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
            //MEVIO.Models.Tasks task = new()
            //{
            //     TaskName = TaskName,
            //     Description = Description,


            //};

            // if (task != null)
            // {

            //     context.Tasks.Add(task);
            //     context.SaveChanges();

            // }



            //Sasha

            context.Tasks.Add(new()
            {
                Description = Description,
                TaskName = TaskName
            });

            await context.SaveChangesAsync();

            return Redirect("/Home/Index");
        }
    }
}
