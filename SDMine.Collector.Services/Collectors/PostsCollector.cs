using Newtonsoft.Json;
using SDMine.Collector.Services.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SDMine.Collector.Services.Collectors
{
    public static class PostsCollector
    {
        public static void Collect(List<string> pages)
        {
            try
            {
                var baseUri = "https://graph.facebook.com/v2.9/";
                var pageId = "f4ep";
                var accessToken = "EAAbT0cUP6NkBAEwM7Jw05zU5mKp1XBRLWwf98XhxeZBBHpRG4fZCEbAbdNc9wZBJYIyVl9aPZBj8YdMSFLwdxWq6cWQFe9UIiZAIIGZAapjsQ4G08kiXA2H6vwI5Jr2Bi5SyUZBDIeYcjex0EFM5rwpcASaQQlS3PUZD";
                var request = new FacebookApiRequest(baseUri, pageId, accessToken)
                {
                    Fields = new List<string>
                {
                    "caption", "created_time", "description", "from","full_picture","icon","id","is_expired","is_hidden",
                    "is_instagram_eligible","is_published","is_spherical","link","message","message_tags","name",
                    "object_id","parent_id","permalink_url","picture","place","privacy","promotion_status","properties",
                    "source", "status_type","story","story_tags","subscribed","timeline_visibility","type","updated_time",
                    "attachments.limit(1000){subattachments,description,description_tags,title,type,url,media}",
                    "comments.limit(1000){created_time,from,id,message,message_tags,comments.limit(1000){created_time,from,id,message,message_tags,reactions.limit(1000){id,type}},reactions.limit(1000){ id, type }}",
                    "reactions.limit(1000){ id,type}","sharedposts.limit(1000){ id,from,to.limit(1000){ id},created_time}","to.limit(1000){ id}&limit=1"
                },
                    Limit = 10
                };

                Collect(request.GetUri());
            }
            catch (Exception ex)
            {

            }
        }

        private static Task Collect(string uri)
        {
            return Task.Factory.StartNew(() =>
            {
                try
                {
                    var client = new HttpClient();

                    var response = client.GetAsync(uri).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var postsList = new List<FacebookPostItem>();
                        var content = response.Content.ReadAsStringAsync().Result;
                        var facebookResponse = JsonConvert.DeserializeObject<FacebookDataItem<FacebookPostItem>>(content);
                        foreach (var item in facebookResponse.Data)
                        {
                            var count = 0;
                            var attachmentTask = CollectAll(item.attachments);
                            var reactionsTask = CollectAll(item.reactions);
                            var sharedPostsTask = CollectAll(item.sharedposts);

                            var commentsTask = CollectAll(item.comments);
                            commentsTask.Wait();
                            foreach (var commentItem in item.comments.Data)
                            {
                                if (commentItem.comments != null)
                                {
                                    commentsTask = CollectAll(commentItem.comments);
                                }
                            }
                            count += item.comments.Data.Count;
                            Task.WaitAll(attachmentTask, commentsTask, reactionsTask, sharedPostsTask);
                            postsList.Add(item);
                        }
                        new PostLoader(postsList).Save();
                        Console.WriteLine("Done");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            });
        }

        private static Task<FacebookDataItem<T>> CollectAll<T>(FacebookDataItem<T> dataItem)
        {
            return Task.Factory.StartNew(() =>
            {
                if (dataItem == null)
                {
                    return null;
                }

                var nextUri = dataItem.Paging != null ? dataItem.Paging.Next : string.Empty;
                while (!string.IsNullOrEmpty(nextUri))
                {
                    try
                    {
                        using (var client = new HttpClient())
                        {
                            var response = client.GetAsync(nextUri).Result;
                            if (response.IsSuccessStatusCode)
                            {
                                var content = response.Content.ReadAsStringAsync().Result;
                                var facebookResponse = JsonConvert.DeserializeObject<FacebookDataItem<T>>(content);

                                dataItem.Data.AddRange(facebookResponse.Data);
                                nextUri = facebookResponse.Paging != null ? facebookResponse.Paging.Next : string.Empty;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                return dataItem;
            });
        }
    }
}
