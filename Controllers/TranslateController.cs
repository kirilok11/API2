using Microsoft.AspNetCore.Mvc;
using API.Clients;
using API.Models;


namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TranslateController : ControllerBase
    {
        private readonly ILogger<TranslateController> _logger;

        public TranslateController(ILogger<TranslateController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "translate")]
        public async Task<TranslationResponse> Place(string TEXT, string from, string to)
        {
            TranslatorClient client = new TranslatorClient();
            return client.TranslateAsync(TEXT, from, to).Result;
        }
    }
}

