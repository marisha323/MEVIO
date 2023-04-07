using Google.Apis.Json;
using Google.Apis.Util.Store;
using Newtonsoft.Json;

namespace MEVIO.Servises
{
    public class GoogleOauthTokenService
    {

        //public class DataStore : IDataStore

        //{

        //    public Task ClearAsync()

        //    {

        //        GoogleOauthTokenService.OauthToken = null;

        //        return Task.Delay(0);

        //    }
        //    public Task DeleteAsync<T>(рядковий ключ)
        //    {
        //        GoogleOauthTokenService.OauthToken = null;
        //        повернути Task.Delay(0);
        //    }


        //    public Task<T> GetAsync<T>(рядковий ключ)
        //    {
        //        var result = GoogleOauthTokenService.OauthToken;
        //        змінне значення = результат == нуль ? default(T) : NewtonsoftJsonSerializer.Instance.Deserialize<T>(результат);
        //        повертає Task.FromResult<T>(значення);
        //    }


        //    public Task StoreAsync<T>(string key, T value)
        //    {
        //        var jsonData = JsonConvert.SerializeObject(value);
        //        GoogleOauthTokenService.OauthToken = jsonData;
        //        return Task.Delay(0);
        //    }
        //}
    }
}
