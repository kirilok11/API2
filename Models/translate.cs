using Newtonsoft.Json;

namespace API.Models
{
    
    
        public class TranslationRequest
        {
            [JsonProperty("text")]
            public string Text { get; set; }

            [JsonProperty("alternative_texts")]
            public List<string> AlternativeTexts { get; set; }
        }

      
    
}
