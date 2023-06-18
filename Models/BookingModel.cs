using Newtonsoft.Json;

namespace API.Models
{
    public class Hotel
    {
        [JsonProperty("hotel_name")]
        public string Name { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("review_score")]
        public string ReviewScore { get; set; }

        [JsonProperty("min_total_price")]
        public decimal MinTotalPrice { get; set; }

      
        
        [JsonProperty("distance_to_cc")]
        public string DistanceFromCC { get; set; }
        [JsonProperty("hotel_include_breakfast")]
        public string IsBreakfastIncluded { get; set; }
        
        [JsonProperty("url")]
        public string Url { get; set; }

    }

    public class RootBook
    {
        [JsonProperty("result")]
        public List<Hotel> Hotels { get; set; }

        [JsonProperty("primary_count")]
        public int PrimaryCount { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }
    }
}
