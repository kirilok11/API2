
using Newtonsoft.Json;
using System.Reflection.PortableExecutable;
using API.Models;
namespace API.Clients

{
    public class SearchNearByClient
    {
      
        public async Task<Root1> SearchNearBynAsync(string lat, string lon, string radius, string lang,int number)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://opentripmap-places-v1.p.rapidapi.com/{lang}/places/radius?radius={radius}&lon={lon}&lat={lat}&limit={number}"),
                //"https://opentripmap-places-v1.p.rapidapi.com/{lang}/places/radius?radius={radius}&lon={lon}&lat={lon}&limit={number}"
                Headers =
    {
        { "X-RapidAPI-Key", "9b3587db25mshd3162b6b27916d3p1bc308jsn1c3fb06019fe" },
        { "X-RapidAPI-Host", "opentripmap-places-v1.p.rapidapi.com" },
    },
            };

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                var responseObject = JsonConvert.DeserializeObject<Root1>(body);
                return responseObject;
                
            }

        }
    }
}
