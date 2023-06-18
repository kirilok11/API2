using Microsoft.AspNetCore.Mvc;
using API.Clients;
using API.Models;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvGeocodingController : ControllerBase
    {
        private readonly ILogger<InvGeocodingController> _logger;

        public InvGeocodingController(ILogger<InvGeocodingController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "invGeocoding")]
        public async Task<Root> Place(string lat, string lon)
        {
            SearchLocationClient client = new SearchLocationClient();
            return client.SearchLocationAsync(lat, lon).Result;
        }

    }
}
