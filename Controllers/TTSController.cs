
using API.Clients;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    
  
    namespace API.Controllers
    {
        [ApiController]
        [Route("[controller]")]
        public class TTSController : ControllerBase
        {


            private readonly ILogger<TTSController> _logger;

            public TTSController(ILogger<TTSController> logger)
            {
                _logger = logger;
            }

            [HttpGet(Name = "TTS")]
            public async Task<TextToSpeach> Speach(string lang, string txt)
            {
                TTSClient tTSClient = new TTSClient();

                var res = tTSClient.ReadTextToSpeachAsync(lang,txt).Result;
                return res;








            }
        }
    }

}
