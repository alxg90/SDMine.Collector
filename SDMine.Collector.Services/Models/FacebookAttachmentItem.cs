using Newtonsoft.Json;
using System.Collections.Generic;

namespace SDMine.Collector.Services.Models
{
    public class FacebookAttachmentItem
    {
        [JsonProperty("subattachments")]
        public FacebookDataItem<FacebookAttachmentItem> subattachments { get; set; }
        [JsonProperty("description")]
        public string description { get; set; }
        [JsonProperty("description_tags")]
        public List<FacebookTagItem> description_tags { get; set; }
        [JsonProperty("title")]
        public string title { get; set; }
        [JsonProperty("type")]
        public string type { get; set; }
        [JsonProperty("url")]
        public string url { get; set; }
        [JsonProperty("media")]
        public FacebookMediaItem media { get; set; }
    }
}
