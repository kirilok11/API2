using API.Models;
using API.Controllers;
using System.Net.Http.Headers;
using Newtonsoft.Json;
namespace API.Clients
{
    public class TranslatorClient
    {
        public async Task<TranslationResponse> TranslateAsync(string text, string SourceLang, string ResultLang)
        {


            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://text-translator2.p.rapidapi.com/translate"),
                Headers =
    {
        { "X-RapidAPI-Key", "9b3587db25mshd3162b6b27916d3p1bc308jsn1c3fb06019fe" },
        { "X-RapidAPI-Host", "text-translator2.p.rapidapi.com" },
    },
                Content = new FormUrlEncodedContent(new Dictionary<string, string>
    {
        { "source_language", $"{SourceLang}" },
        { "target_language", $"{ResultLang}" },
        { "text", $"{text}" },
    }),
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var responseObject = JsonConvert.DeserializeObject<TranslationResponse>(body);
                return responseObject;
            }
            
            
           
            
        }
    }
}
        

