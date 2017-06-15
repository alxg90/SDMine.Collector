using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SDMine.Collector.Services.Models
{
    public class FacebookPostItem
    {
        [JsonProperty("caption")]
        public string caption { get; set; }
        [JsonProperty("created_time")]
        public DateTime created_time { get; set; }
        [JsonProperty("description")]
        public string description { get; set; }
        [JsonProperty("from")]
        public FacebookFromItem from { get; set; }
        [JsonProperty("full_picture")]
        public string full_picture { get; set; }
        [JsonProperty("icon")]
        public string icon { get; set; }
        [JsonProperty("id")]
        public string id { get; set; }      //TODO: split to id_first(long) and id_last(long)

        public long id_first
        {
            get
            {
                if (string.IsNullOrEmpty(id))
                {
                    return 0;
                }

                var ids = id.Split('_');
                if (ids.Length == 0)
                {
                    return 0;
                }

                long tmpId;
                if (long.TryParse(id.Split('_')[0], out tmpId))
                {
                    return tmpId;
                }
                return 0;
            }
        }

        public long id_last
        {
            get
            {
                if (string.IsNullOrEmpty(id))
                {
                    return 0;
                }

                var ids = id.Split('_');
                if (ids.Length == 0)
                {
                    return 0;
                }

                long tmpId;
                if (long.TryParse(id.Split('_')[1], out tmpId))
                {
                    return tmpId;
                }
                return 0;
            }
        }

        [JsonProperty("is_expired")]
        public bool? is_expired { get; set; }
        [JsonProperty("is_hidden")]
        public bool? is_hidden { get; set; }
        [JsonProperty("is_instagram_eligible")]
        public bool? is_instagram_eligible { get; set; }
        [JsonProperty("is_published")]
        public bool? is_published { get; set; }
        [JsonProperty("is_spherical")]
        public bool? is_spherical { get; set; }
        [JsonProperty("link")]
        public string link { get; set; }
        [JsonProperty("message")]
        public string message { get; set; }
        [JsonProperty("message_tags")]
        public List<FacebookTagItem> message_tags { get; set; }
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("object_id")]
        public long? object_id { get; set; }
        [JsonProperty("parent_id")]
        public string parent_id { get; set; }   //TODO: split to parent_id_first and parent_id_last
        [JsonProperty("permalink_url")]
        public string permalink_url { get; set; }
        [JsonProperty("picture")]
        public string picture { get; set; }
        [JsonProperty("place")]
        public FacebookPlaceItem place { get; set; }
        [JsonProperty("privacy")]
        public FacebookPrivacyItem privacy { get; set; }
        [JsonProperty("promotion_status")]
        public string promotion_status { get; set; }
        [JsonProperty("properties")]
        public List<FacebookPostPropertyItem> properties { get; set; }
        [JsonProperty("source")]
        public string source { get; set; }
        [JsonProperty("status_type")]
        public string status_type { get; set; }
        [JsonProperty("story")]
        public string story { get; set; }
        [JsonProperty("story_tags")]
        public List<FacebookTagItem> story_tags { get; set; }
        [JsonProperty("subscribed")]
        public bool? subscribed { get; set; }
        [JsonProperty("timeline_visibility")]
        public string timeline_visibility { get; set; }
        [JsonProperty("type")]
        public string type { get; set; }
        [JsonProperty("updated_time")]
        public DateTime? updated_time { get; set; }
        [JsonProperty("attachments")]
        public FacebookDataItem<FacebookAttachmentItem> attachments { get; set; }
        [JsonProperty("comments")]
        public FacebookDataItem<FacebookCommentItem> comments { get; set; }
        [JsonProperty("reactions")]
        public FacebookDataItem<FacebookReactionItem> reactions { get; set; }
        [JsonProperty("sharedposts")]
        public FacebookDataItem<FacebookPostItem> sharedposts { get; set; }
        [JsonProperty("to")]
        public FacebookDataItem<FacebookToItem> to { get; set; }
    }
}
