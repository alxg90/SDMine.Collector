using Newtonsoft.Json;

namespace SDMine.Collector.Services.Models
{
    public class FacebookLocationItem
    {
        [JsonProperty("city")]
        public string city { get; set; }
        [JsonProperty("country")]
        public string country { get; set; }
        [JsonProperty("latitude")]
        public double? latitude { get; set; }
        [JsonProperty("longitude")]
        public double? longitude { get; set; }
        [JsonProperty("street")]
        public string street { get; set; }
        [JsonProperty("zip")]
        public string zip { get; set; }
    }
}
