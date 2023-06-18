using API.Models;
using API.Controllers;
using System.Net.Http.Headers;
using Newtonsoft.Json;
namespace API.Clients
{
    public class TranslatorClient
    {
        public async Task<TranslationRequest> Translate(string text, string SourceLang, string ResultLang)
        {
            
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://deepl-translator.p.rapidapi.com/translate"),
                Headers =
    {
        { "X-RapidAPI-Key", "9b3587db25mshd3162b6b27916d3p1bc308jsn1c3fb06019fe" },
        { "X-RapidAPI-Host", "deepl-translator.p.rapidapi.com" },
    },
                Content = new StringContent("{\r\n\"text\": \""+text+"\",\r\n\"source\": \""+SourceLang+"\",\r\n\"target\": \""+ResultLang+"\"\r\n}")
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
                var responseObject = JsonConvert.DeserializeObject<TranslationRequest>(body);
                return responseObject;
            }
           
            
        }
    }
}
        

