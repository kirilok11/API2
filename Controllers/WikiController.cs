using Microsoft.AspNetCore.Mvc;
using API.Clients;
using API.Models;

namespace API.Controllers
{
   
    [ApiController]
    [Route("[controller]")]
    public class WikiController : ControllerBase
    {
        private readonly ILogger<WikiController> _logger;

        public WikiController(ILogger<WikiController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "wiki")]
        public async Task<WikiResponse> Place(string TEXT, int NumberOfArticles)
        {
            WikiClient client = new WikiClient();
            return client.WikiSearch(TEXT, NumberOfArticles).Result;
        }
    }
}
