using Microsoft.AspNetCore.Mvc;
using API.Clients;
using API.Models;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GPTcontrollercs : ControllerBase
    {
        private readonly ILogger<GPTcontrollercs> _logger;

        public GPTcontrollercs(ILogger<GPTcontrollercs> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "gpt")]
        public async Task<APIResponse> Place(string cont)
        {
            GptClient client = new GptClient();

            return client.ChatRespone(cont).Result;
        }
    }
}


