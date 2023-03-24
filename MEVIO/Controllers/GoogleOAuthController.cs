//using Google.Apis.Auth;
using Mevio2Test.Helhers;
using Mevio2Test.Servises;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
//using Google.Apis.Auth.OAuth2.Mvc;
//using Google.Apis.Json;
//using Google.Apis.Plus.v1;
//using Google.Apis.Plus.v1.Data;
//using Google.Apis.Services;
//using Google.Apis.Util.Store;




namespace Mevio2Test.Controllers
{
    public class GoogleOAuthController : Controller
    {
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
           // return Redirect (url);
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



        //[HttpPost]
        //public async Task<ActionResult> SignInWithGoogle(string id_token)
        //{
        //    try
        //    {
        //        // Verify the Google ID token
        //        var tokenVerifier = new GoogleJsonWebSignature.ValidationSettings
        //        {
        //            Audience = new[] { "<your-client-id>.apps.googleusercontent.com" }
        //        };
        //        var payload = await GoogleJsonWebSignature.ValidateAsync(id_token, tokenVerifier);

        //        // Retrieve the user's profile information from the Google API
        //        var userId = payload.Subject;
        //        var name = payload.Name;
        //        var email = payload.Email;

        //        // Create a new account on your website using the retrieved information
        //        // ...

        //        // Return a success response to the client

        //     return ContentResult(JsonConvert.SerializeObject(new { success = true }), "application/json");


        //    }
        //    catch (Exception ex)
        //    {
        //        // Return an error response to the client
        //       // return Json(new { success = false, error = ex.Message });
        //    }


    }
}

