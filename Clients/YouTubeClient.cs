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
            string restext = "";
            for (int c = 0; c < text.Length; c++)
            {
                if (text[c] == ' ')
                {
                    restext = restext + "%20";
                }
                else
                {
                    restext = restext + text[c];
                }

            }


            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://youtube-search-results.p.rapidapi.com/youtube-search/?q={restext}"),
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
