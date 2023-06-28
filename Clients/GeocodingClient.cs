using Newtonsoft.Json;
using API.Models;
using static API.Models.GeometryData;
using System.Web;

namespace API.Clients
{
    public class GeocodingClient
    {
        public async Task<GeocodingResponse> SearchLocationAsync(string lng, string PlaceName)
        {
            
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://google-maps-geocoding.p.rapidapi.com/geocode/json?address={PlaceName}&language={lng}"),
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

                var responseObject = JsonConvert.DeserializeObject<GeocodingResponse>(body);
                return responseObject;

            }

        }
    }
}
