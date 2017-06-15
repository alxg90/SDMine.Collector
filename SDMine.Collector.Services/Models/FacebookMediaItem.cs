using Newtonsoft.Json;

namespace SDMine.Collector.Services.Models
{
    public class FacebookMediaItem
    {
        [JsonProperty("image")]
        public FacebookImageItem image { get; set; }
    }
}
