using Newtonsoft.Json;
using System.Reflection.PortableExecutable;

namespace API.Clients
{
    public class SearchLocationClient
    {

        public async Task<Root> SearchLocationAsync(string lat, string lon)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://google-maps-geocoding.p.rapidapi.com/geocode/json?latlng={lat}%2C{lon}&language=en"),
                Headers =
    {
            { "X-RapidAPI-Key", "9b3587db25mshd3162b6b27916d3p1bc308jsn1c3fb06019fe" },
            { "X-RapidAPI-Host", "google-maps-geocoding.p.rapidapi.com" },
    },
            };

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                var responseObject = JsonConvert.DeserializeObject<Root>(body);
                return responseObject;
                
            }

        }
    }
}
