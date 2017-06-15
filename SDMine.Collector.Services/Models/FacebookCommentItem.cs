using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SDMine.Collector.Services.Models
{
    public class FacebookCommentItem
    {
        [JsonProperty("created_time")]
        public DateTime created_time { get; set; }
        [JsonProperty("from")]
        public FacebookFromItem from { get; set; }
        [JsonProperty("id")]
        public string id { get; set; }  //TODO: split to id_first(long) and id_last(long)
        [JsonProperty("message")]
        public string message { get; set; }
        [JsonProperty("message_tags")]
        public List<FacebookTagItem> message_tags { get; set; }
        [JsonProperty("reactions")]
        public FacebookDataItem<FacebookReactionItem> reactions { get; set; }
        [JsonProperty("comments")]
        public FacebookDataItem<FacebookCommentItem> comments { get; set; }
    }
}
