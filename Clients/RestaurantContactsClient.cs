using API.Models;
using Newtonsoft.Json;

namespace API.Clients
{
    public class RestaurantContactsClient
    {
        private HttpClient _httpClient;
        private static string _address;
        private static string _apikey;
        public RestaurantContactsClient()
        {
            _address = Constants.address;
            _apikey = Constants.apikey;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_address);

        }
        public async Task<Contacts> SearchContactsAsync(string placeId)
        {
            var response = await _httpClient.GetAsync($"/maps/api/place/details/json?place_id={placeId}&fields=name%2Crating%2Cformatted_phone_number%2Cformatted_address%2Cdelivery%2Curl&key={_apikey}");
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;

            var responseObject = JsonConvert.DeserializeObject<Contacts>(content);
            return responseObject;

        }
    }
}
