using Mevio2Test.Helhers;
using Microsoft.AspNetCore.WebUtilities;

namespace Mevio.Servises
{
    public class GoogleOAuthService
    {
        private const string ClientId = "715700270542-m2iv2jqmaue49o43d969evbivc5jqj1s.apps.googleusercontent.com";

        private const string ClientSecret = "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";
        private const string TokenServerEndpoint = "https://oauth2.googleapis.com/token";



        public static string GenerateOAuthRequestUrl(string scope, string redirectUrl, string codeChallenge) //генерування запиту до сервера авторизації(url, де в  get request будуть параметри для авторизації користувача)
        {
            var oAuthServerEndPoint = "https://accounts.google.com/o/oauth2/v2/auth";


            var queryParams = new Dictionary<string, string>
            {
                {"client_id",ClientId },
                {"redirect_uri",redirectUrl  },
                {"response_type","code" },
                {"scope",scope },
                {"code_challenge",codeChallenge },
                {"code_challenge_method", "S256" },
                {"access_type", "offline" }

            };
            var url = QueryHelpers.AddQueryString(oAuthServerEndPoint, queryParams);

            return url;

        }

        public static async Task<TokenResult> ExchangeCodeOnTokenAsync(string code, string codeVerifier, string redirectUrl) //обмін коду авторизаціїї на аксес та  рефреш токен
        {
            var tokenEndPoint = "https://oauth2.googleapis.com/token";

            var authParams = new Dictionary<string, string>
            {
                {"client_id", ClientId },
                {"client_secret", ClientSecret },
                {"code",code },
                {"code_verifier", codeVerifier },
                {"grant_type","authorization_code" },
                {"redirect_uri" ,redirectUrl}

            };
            var tokenResult = await HttpClientHelper.SendPostRequest<TokenResult>(tokenEndPoint, authParams);

            return tokenResult;
        }

        public static async Task<TokenResult> RefreshTokenAsync(string refreshToken)
        {
            var refreshEndpoint ="https://oauth2.googleapis.com/token";
            var refreshParams = new Dictionary<string, string>
            {
                { "client_id", ClientId },
                { "client_secret", ClientSecret },
                { "grant_type", "refresh_token" },
                { "refresh_token", refreshToken }
            };

            var tokenResult = await HttpClientHelper.SendPostRequest<TokenResult>(refreshEndpoint, refreshParams);

            return tokenResult;
        }
    }


}

