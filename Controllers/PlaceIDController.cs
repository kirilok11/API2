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

        [HttpGet(Name = "place id for booking")]
        public async Task<List<CityData>> Place(string place)
        {
            PlaceIDBookingClient client = new PlaceIDBookingClient();
            return client.SearchPlaceID(place ).Result;
        }
    }
}
