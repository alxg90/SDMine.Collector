using Newtonsoft.Json;

namespace SDMine.Collector.Services.Models
{
    public class FacebookReactionItem
    {
        [JsonProperty("id")]
        public long id { get; set; }
        [JsonProperty("type")]
        public string type { get; set; }
    }
}
