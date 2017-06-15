using Newtonsoft.Json;

namespace SDMine.Collector.Services.Models
{
    public class FacebookPagingItem
    {
        [JsonProperty("next")]
        public string Next { get; set; }
    }
}
