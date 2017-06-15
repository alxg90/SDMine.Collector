using Newtonsoft.Json;

namespace SDMine.Collector.Services.Models
{
    public class FacebookToItem
    {
        [JsonProperty("id")]
        public long id { get; set; }
    }
}
