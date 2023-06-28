using Newtonsoft.Json;

namespace API.Models
{


    
    public class TranslationResponse
    {
        public string status { get; set; }
        public ApiDatax data { get; set; }
    }

    public class ApiDatax
    {
        public string translatedText { get; set; }
    }



}
