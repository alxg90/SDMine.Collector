using Newtonsoft.Json;

namespace SDMine.Collector.Services.Models
{
    public class FacebookMemberItem
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("administrator")]
        public bool Administrator { get; set; }
    }
}
