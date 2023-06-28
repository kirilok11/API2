using Azure.Core;
using Azure;
using API.Models;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace API.Clients
{
    public class TTSClient
    {
        public async Task<TextToSpeach> ReadTextToSpeachAsync(string lang, string txt)
        {


            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"https://text-to-speech79.p.rapidapi.com/text_to_speech/?input_text={txt}&speaking_rate=1&pitch=1&language_code={lang}&voice_type={lang}-Neural2-J&ssml_gender=MALE"),
                Headers =
    {
        { "X-RapidAPI-Key", "9b3587db25mshd3162b6b27916d3p1bc308jsn1c3fb06019fe" },
        { "X-RapidAPI-Host", "text-to-speech79.p.rapidapi.com" },
    },
                Content = new StringContent("{\r\n    \"key1\": \"value\",\r\n    \"key2\": \"value\"\r\n}")
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
                var responseObject = JsonConvert.DeserializeObject<TextToSpeach>(body);
                return responseObject;

            }
        }

    }
}
