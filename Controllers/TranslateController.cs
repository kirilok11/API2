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

        [HttpPost(Name = "translate")]
        public async Task<TranslationRequest> Place(string TEXT, string from, string to)
        {
            TranslatorClient client = new TranslatorClient();
            return client.Translate(TEXT, from, to).Result;
        }
    }
}

