using API.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Web;
using API.Models;

namespace API.Clients
{

    public class PlaceIDBookingClient
    {
        public async Task<List<CityData>> SearchPlaceID(string place, string lng)
        {
            
            string encoded = HttpUtility.UrlEncode(place);
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?name={encoded}&locale={lng}"),
                Headers =
                    {
                    { "X-RapidAPI-Key", "9b3587db25mshd3162b6b27916d3p1bc308jsn1c3fb06019fe" },
                    { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
                    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var responseObject = JsonConvert.DeserializeObject<List<CityData>>(body);
                return responseObject;
            }
        }
    }
   
    
}
