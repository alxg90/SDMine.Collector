using Newtonsoft.Json;
using System.Collections.Generic;

namespace SDMine.Collector.Services.Models
{
    public class FacebookDataItem<T>
    {
        [JsonProperty("data")]
        public List<T> Data { get; set; }

        [JsonProperty("paging")]
        public FacebookPagingItem Paging { get; set; }
    }
}
