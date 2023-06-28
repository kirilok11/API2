using Microsoft.AspNetCore.Mvc;
using API.Clients;
using API.Models;

namespace API.Controllers
{
   
    [ApiController]
    [Route("[controller]")]
    public class RestaurantContactsController : ControllerBase
    {


        private readonly ILogger<RestaurantContactsController> _logger;

        public RestaurantContactsController(ILogger<RestaurantContactsController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "RestaurantsContacts")]
        public async Task<Contacts> Place(string PlaceID)
        {
            RestaurantContactsClient client = new RestaurantContactsClient();
            return client.SearchContactsAsync(PlaceID).Result;
        }
    }
}
