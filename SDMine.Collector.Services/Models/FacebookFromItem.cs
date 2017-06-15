using Newtonsoft.Json;

namespace SDMine.Collector.Services.Models
{
    public class FacebookFromItem
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("id")]
        public long ID { get; set; }
    }
}
