using API.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
namespace API.Clients
{
    public class BookingClient
    {
        public async Task<RootBook> SearchHotels(string CheckInDate, string DestType, string CheckOutDate, string NumOfAdults, string DestId, string NumOfRooms, string NumOfChildren, string AgeOfChildren ) 
        {
            
            int c = int.Parse(NumOfChildren);
            if (c > 0) 
            {
                NumOfChildren = $"&children_number={NumOfChildren}";
            }
            else { NumOfChildren = "";AgeOfChildren = "0"; }
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/search?checkin_date={CheckInDate}&dest_type={DestType}&units=metric&checkout_date={CheckOutDate}&adults_number={NumOfAdults}&order_by=popularity&dest_id={DestId}&filter_by_currency=USD&locale=en-gb&room_number={NumOfRooms}{NumOfChildren}&children_ages={AgeOfChildren}&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1&page_number=0&include_adjacency=true"),
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
                var responseObject = JsonConvert.DeserializeObject<RootBook>(body);
                return responseObject;
            }
        }

    }
}
