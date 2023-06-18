
using Microsoft.AspNetCore.Mvc;
using API.Clients;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlacesConroller : ControllerBase
    {
      

        private readonly ILogger<PlacesConroller> _logger;

        public PlacesConroller(ILogger<PlacesConroller> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "PlacesAround")]
        public async Task< Root3> Place(string LAT, string LON, string RAD, string KIND, string KEYWORD) 
        {
            ReustarantsAndHotelsAroundClient client = new ReustarantsAndHotelsAroundClient();
            return client.SearchReustarantsAsync(LAT, LON, RAD, KIND, KEYWORD).Result;
        }
    }
}
