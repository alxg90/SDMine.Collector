using Newtonsoft.Json;

namespace SDMine.Collector.Services.Models
{
    public class FacebookTagItem
    {
        [JsonProperty("id")]
        public long id { get; set; }
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("type")]
        public string type { get; set; }
    }
}
