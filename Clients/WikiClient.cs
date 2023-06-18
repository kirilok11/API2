using System.Net.Http.Headers;
using API.Controllers;
using API.Models;
using Newtonsoft.Json;

namespace API.Clients
{
    public class WikiClient
    {
        public async Task<WikiResponse> WikiSearch(string topic, int Paragraphs) 
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://wiki-briefs.p.rapidapi.com/search?q={topic}&topk={Paragraphs}"),
                Headers =
    {
        { "X-RapidAPI-Key", "9b3587db25mshd3162b6b27916d3p1bc308jsn1c3fb06019fe" },
        { "X-RapidAPI-Host", "wiki-briefs.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var responseObject = JsonConvert.DeserializeObject<WikiResponse>(body);
                return responseObject;
            }
        }

    }
}
