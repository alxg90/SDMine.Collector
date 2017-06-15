using Newtonsoft.Json;

namespace SDMine.Collector.Services.Models
{
    public class FacebookPostPropertyItem
    {
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("text")]
        public string text { get; set; }
    }
}
