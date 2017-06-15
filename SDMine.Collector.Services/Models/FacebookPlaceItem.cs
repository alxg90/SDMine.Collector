using Newtonsoft.Json;

namespace SDMine.Collector.Services.Models
{
    public class FacebookPlaceItem
    {
        [JsonProperty("id")]
        public long id { get; set; }
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("location")]
        public FacebookLocationItem location { get; set; }
    }
}
