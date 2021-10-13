using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebmotorsAnuncio.Clients
{
    public abstract class OnlineChallengeClient
    {

        protected HttpClient HttpClient { get; }

        public OnlineChallengeClient()
        {
            HttpClient = new HttpClient();
            //HttpClient.BaseAddress = new Uri("https://desafioonline.webmotors.com.br/api/OnlineChallenge");
        }

        public T SendGetRequest<T>(string url)
        {
            var clientResponse = HttpClient.GetAsync("https://desafioonline.webmotors.com.br/api/OnlineChallenge/"+ url).Result;
            clientResponse.EnsureSuccessStatusCode();
            var responseContent = clientResponse.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<T>(responseContent);
        }
    }


}