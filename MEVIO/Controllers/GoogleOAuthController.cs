//using Google.Apis.Auth;
using Mevio2Test.Helhers;
using Mevio.Servises;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


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
      string scopesString = string.Join("", scopes2);

      // string scopesString = "https://www.googleapis.com/auth/userinfo.email";

        //var url = GoogleOAuthService.GenerateOAuthRequestUrl(scopesString, redirectUrl, codeChellange);

        private const string redirectUrl = "https://localhost:7146/GoogleOauth/Code";

        private const string PkceSessionKey = "codeVerifier";


        public IActionResult RedirectOnOAuthServer()
        {
            var codeVerifier = Guid.NewGuid().ToString();

            HttpContext.Session.SetString(PkceSessionKey, codeVerifier);

            var codeChellange = Sha256Helper.ComputeHash(codeVerifier);


            var url = GoogleOAuthService.GenerateOAuthRequestUrl(scopesString, redirectUrl, codeChellange);


            return Redirect(url);
           // return Redirect (url);
        }


        public async Task<IActionResult> CodeAsync(string code)
        {
       
           
            string codeVerifier = HttpContext.Session.GetString(PkceSessionKey);
            

            var tokenResult = GoogleOAuthService.ExchangeCodeOnTokenAsync(code, codeVerifier, redirectUrl);

            //// Получение информации о профиле пользователя
            var userInfoUrl = "https://www.googleapis.com/oauth2/v1/userinfo?alt=json&access_token=" + tokenResult.Status;
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(userInfoUrl);
            response.EnsureSuccessStatusCode();

            //// Извлечение электронной почты из ответа API
            var userInfoJson = await response.Content.ReadAsStringAsync();
            dynamic userInfo = JsonConvert.DeserializeObject(userInfoJson);
            string email = userInfo.email;

            // Почекаємо 3600 секунд
            // (саме стільки можна використовувати AccessToken, поки його термін придатності не спливе).

            // І оновлюємо Токен Доступу за допомогою Refresh-токена.
          //  var refreshedTokenResult = await GoogleOAuthService.RefreshTokenAsync(tokenResult.Result);

            return Redirect("/MainPage/MainPage");

        }



        

    }
}

