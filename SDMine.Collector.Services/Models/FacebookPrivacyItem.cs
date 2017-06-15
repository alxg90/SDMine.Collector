using Newtonsoft.Json;

namespace SDMine.Collector.Services.Models
{
    public class FacebookPrivacyItem
    {
        [JsonProperty("value")]
        public string value { get; set; }
        [JsonProperty("description")]
        public string description { get; set; }
        [JsonProperty("friends")]
        public string friends { get; set; }
        [JsonProperty("allow")]
        public string allow { get; set; }
        [JsonProperty("deny")]
        public string deny { get; set; }
    }
}
