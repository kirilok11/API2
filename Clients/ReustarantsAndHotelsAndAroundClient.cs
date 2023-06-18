using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;
using System.Text;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace API.Clients
{
    public class ReustarantsAndHotelsAroundClient
    {
        private HttpClient _httpClient;
        private static string _address;
        private static string _apikey;
        public ReustarantsAndHotelsAroundClient() 
        {
            _address = Constants.address;
            _apikey=Constants.apikey;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_address);

        }
        public async Task<Root3> SearchReustarantsAsync(string lat, string lon,string rad, string kind, string keyword)
        {
            var response = await _httpClient.GetAsync($"/maps/api/place/nearbysearch/json?location={lat}%2C{lon}&radius={rad}&type={kind}&keyword={keyword}&key={_apikey}");
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;

            var responseObject = JsonConvert.DeserializeObject<Root3>(content);
            return responseObject;

        }
    }
    }

