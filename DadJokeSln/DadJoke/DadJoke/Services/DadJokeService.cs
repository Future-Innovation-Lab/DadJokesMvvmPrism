using DadJokes.Models.Service;
using DadJokes.Services.Interfaces;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace DadJokes.Services
{
    public class DadJokeService : IRemoteServer
    {
        public async Task<DadJoke> GetRemoteJoke()
        {

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");


            string response = await client.GetStringAsync("https://icanhazdadjoke.com/");

            DadJoke joke = JsonConvert.DeserializeObject<DadJoke>(response);

            return joke;

        }
    }
}
