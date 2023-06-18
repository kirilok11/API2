using Microsoft.AspNetCore.Mvc;
using API.Clients;
using API.Models;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class YouTubeController : ControllerBase
    {
        private readonly ILogger<YouTubeController> _logger;

        public YouTubeController(ILogger<YouTubeController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "search on yt")]
        public async Task<ApiResponseYT> Place(string TEXT)
        {
            YouTubeClient client = new YouTubeClient();
            return client.SearchOnYT(TEXT).Result;
        }
    }
}
