using Microsoft.AspNetCore.Mvc;
using API.Clients;
using API.Models;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlaceIDController : ControllerBase
    {
        private readonly ILogger<PlaceIDController> _logger;

        public PlaceIDController(ILogger<PlaceIDController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "place id")]
        public async Task<List<CityData>> Place(string place,string lng)
        {
            PlaceIDBookingClient client = new PlaceIDBookingClient();
            return client.SearchPlaceID(lng,place ).Result;
        }
    }
}
