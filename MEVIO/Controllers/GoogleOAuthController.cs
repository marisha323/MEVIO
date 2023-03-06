using Mevio2Test.Helhers;
using Mevio2Test.Servises;
using Microsoft.AspNetCore.Mvc;

namespace Mevio2Test.Controllers
{
    public class GoogleOAuthController : Controller
    {
        //private const string scope = "https://www.googleapis.com/auth/userinfo.email";
        // private const string scope = "https://www.googleapis.com/auth/userinfo.email";

      string[] scope =new [] {"https://www.googleapis.com/auth/userinfo.email",
            
                            "https://www.googleapis.com/auth/userinfo.profile" };// доступ до інформації профілu  // доступ до адреси електронної пошти

    private const string redirectUrl = "http://localhost:5001/GoogleOauth/Code";
        private const string PkceSessionKey = "codeVerifier";

        public IActionResult Index()
        {
            return View();
        }


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


            var url = GoogleOAuthService.GenerateOAuthRequestUrl(scope[0], redirectUrl, codeChellange);

            return Redirect(url);
        }


        public async Task<IActionResult> CodeAsync(string code)
        {

            string codeVerifier = HttpContext.Session.GetString("codeVerifier");
            var redirectUrl = "http://localhost:5001/GoogleOauth/Code";

            var tokenResult = GoogleOAuthService.ExchangeCodeOnToken(code, codeVerifier, redirectUrl);

            return Ok();

        }
    }
}

