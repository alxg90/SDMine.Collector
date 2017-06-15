using Newtonsoft.Json;

namespace SDMine.Collector.Services.Models
{
    public class FacebookImageItem
    {
        [JsonProperty("height")]
        public int height { get; set; }
        [JsonProperty("src")]
        public string src { get; set; }
        [JsonProperty("width")]
        public int width { get; set; }
    }
}
