
using Microsoft.AspNetCore.Mvc;
using API.Clients;
using System.Runtime.CompilerServices;
using API.Models;
namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NearBY : ControllerBase
    {


        private readonly ILogger<PlacesConroller> _logger;

        public NearBY(ILogger<PlacesConroller> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "PlacesAround1")]
        public async Task <Root1> Place1(string LAT, string LON, string RAD, string LANG, int NUM)
        {
            SearchNearByClient client = new SearchNearByClient();
            var res = client.SearchNearBynAsync(LAT, LON, RAD,LANG, NUM).Result;
            return res;

               
                
                   

                
            
            
        }
    }
}
