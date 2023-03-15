using MEVIO.Models;
using Mevio2Test.Helhers;
using Mevio2Test.Servises;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text.Json;


namespace MEVIO.Controllers
{
    public class RegistryController : Controller
    {
        public MEVIOContext context;

        public RegistryController( MEVIOContext context) {
        
        this.context = context;
        } 


        string[] scopes = new[] { "https://www.googleapis.com/auth/userinfo.email", "https://www.googleapis.com/auth/userinfo.profile" };

        static List<string> scopes2 = new List<string>()
        {
           "https://www.googleapis.com/auth/userinfo.email",
            "https://www.googleapis.com/auth/userinfo.profile"
        };
        string scopesString = string.Join(" ", scopes2);
        //var url = GoogleOAuthService.GenerateOAuthRequestUrl(scopesString, redirectUrl, codeChellange);

        private const string redirectUrl = "http://localhost:5001/GoogleOauth/Code";

        private const string PkceSessionKey = "codeVerifier";



        public IActionResult Index() => View();



        public IActionResult RedirectOnOAuthServer()
        {

            //// Права доступа
            //const GOOGLE_SCOPES = [
            //    'https://www.googleapis.com/auth/userinfo.email', // доступ до адреси електронної пошти
            //    'https://www.googleapis.com/auth/userinfo.profile' // доступ до інформації профілю
            //];

            //// Посилання на аутентифікацію
            //const GOOGLE_AUTH_URI = 'https://accounts.google.com/o/oauth2/auth';

            //// Посилання на отримання токена
            //const GOOGLE_TOKEN_URI = 'https://accounts.google.com/o/oauth2/token';

            //// Посилання на отримання інформації про користувача
            //const GOOGLE_USER_INFO_URI = 'https://www.googleapis.com/oauth2/v1/userinfo';

            var codeVerifier = Guid.NewGuid().ToString();

            HttpContext.Session.SetString(PkceSessionKey, codeVerifier);

            var codeChellange = Sha256Helper.ComputeHash(codeVerifier);


            var url = GoogleOAuthService.GenerateOAuthRequestUrl(scopesString, redirectUrl, codeChellange);

            return Redirect(url);
        }


        public async Task<IActionResult> CodeAsync(string code)
        {

            string codeVerifier = HttpContext.Session.GetString("codeVerifier");
            var redirectUrl = "http://localhost:5001/GoogleOauth/Code";

            var tokenResult = GoogleOAuthService.ExchangeCodeOnTokenAsync(code, codeVerifier, redirectUrl);



            // Почекаємо 3600 секунд
            // (саме стільки можна використовувати AccessToken, поки його термін придатності не спливе).

            // І оновлюємо Токен Доступу за допомогою Refresh-токена.
            // var refreshedTokenResult = await GoogleOAuthService.RefreshTokenAsync(tokenResult.);

            return Ok();

        }



        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            User user = context.Users.Where(o => o.Email == email && o.Password == password).AsNoTracking().FirstOrDefault();
            if (user != null)
            {
                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.Now.AddMinutes(45);
                options.IsEssential = true;
                options.Path = "/";

                string str = System.Text.Json.JsonSerializer.Serialize(user);

                HttpContext.Response.Cookies.Append("UserLoggedIn", str, options);
                return Redirect("Index");
                //return RedirectToAction("Index", "Main");
            }
            else
            {
                return View("LoginRegister");
            }

        }

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

