using MEVIO.Models;
using MEVIO.Models.StartInitial;
using Mevio2Test.Helhers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Drawing;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace MEVIO.Controllers
{
    public class RegistryController : Controller
    {
        public MEVIOContext context;

        public RegistryController(MEVIOContext context)
        {
            this.context = context;
            //StartInit();
        }

        protected void InitRoles()
        {
            UserRole roleadmin = new UserRole() { UserRoleName = "admin" };
            UserRole roledirector = new UserRole() { UserRoleName = "director" };
            UserRole rolemanager = new UserRole() { UserRoleName = "manager" };
            UserRole roleuser = new UserRole() { UserRoleName = "user" };
            context.UserRoles.Add(roleadmin);
            context.UserRoles.Add(roledirector);
            context.UserRoles.Add(rolemanager);
            context.UserRoles.Add(roleuser);
            context.SaveChanges();
        }

        protected void StartInit()
        {
            var init = new MyInitial(context);

            InitRoles();
            init.InitClients();
            init.InitUsers();
            init.InitEvents();
            init.InitTasks();
            init.InitMeasures();




        }

        public IActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            User user = context.Users.Where(o => o.Email == email && o.Password == password).AsNoTracking().FirstOrDefault();
            if (user != null)
            {
                //Sasha
                user.LastTimeSignIn = DateTime.Now;

                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.Now.AddDays(6);
                options.IsEssential = true;
                options.Path = "/";

                string str = JsonSerializer.Serialize(user);

                HttpContext.Response.Cookies.Append("UserLoggedIn", str, options);


               
                 return Redirect("/MainPage/MainPage");
               
            }
            else
            {
                return Redirect("Index");
            }

        }

        [Authorize]
        public async Task<IActionResult> MyProtectedAction()
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);

            // Перевірка, чи існує користувач в базі даних
            if (user == null)
            {
                return Forbid();
            }
            return View("/MainPage/MainPage");
            // Код захищеної дії
        }

        [HttpGet]
        public IActionResult Logout()
        {
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now;
            options.IsEssential = true;
            options.Path = "/";

            HttpContext.Response.Cookies.Append("UserLoggedIn", "", options);

            return Redirect("Index");
        }
    }
}

