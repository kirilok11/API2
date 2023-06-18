using API.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
namespace API.Clients
{
    public class GptClient
    {
        public async Task<APIResponse> ChatRespone(string content) 
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://openai80.p.rapidapi.com/chat/completions"),
                Headers =
            {
            { "X-RapidAPI-Key", "9b3587db25mshd3162b6b27916d3p1bc308jsn1c3fb06019fe" },
            { "X-RapidAPI-Host", "openai80.p.rapidapi.com" },
            },
                Content = new StringContent("{\r\n\"model\": \"gpt-3.5-turbo\",\r\n\"messages\": [\r\n{\r\n\"role\": \"user\",\r\n\"content\": \""+content+"\"\r\n}\r\n]\r\n}")
                {
                    Headers =
            {
            ContentType = new MediaTypeHeaderValue("application/json")
            }
                }
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var responseObject = JsonConvert.DeserializeObject<APIResponse>(body);
                return responseObject;
            }
        }
    }
        
}
