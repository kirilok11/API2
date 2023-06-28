using API.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Linq;
namespace API.Clients
{
    public class YouTubeClient
    {
        public async Task<ApiResponseYT> SearchOnYT(string text) 
        {
            

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://youtube-search-results.p.rapidapi.com/youtube-search/?q={text}"),
                Headers =
    {
        { "X-RapidAPI-Key", "9b3587db25mshd3162b6b27916d3p1bc308jsn1c3fb06019fe" },
        { "X-RapidAPI-Host", "youtube-search-results.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var responseObject = JsonConvert.DeserializeObject<ApiResponseYT>(body);
                return responseObject;
            }
        }

    }
}
