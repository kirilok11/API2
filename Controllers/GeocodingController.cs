using Microsoft.AspNetCore.Mvc;
using API.Clients;
using static API.Models.GeometryData;

namespace API.Controllers
{
   
    [ApiController]
    [Route("[controller]")]
    public class GeocodingController : ControllerBase
    {
        private readonly ILogger<GeocodingController> _logger;

        public GeocodingController(ILogger<GeocodingController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "Geocoding")]
        public async Task<GeocodingResponse> Place(string lng, string address)
        {
            GeocodingClient client = new GeocodingClient();
            return client.SearchLocationAsync(lng, address).Result;
        }

    }
}
