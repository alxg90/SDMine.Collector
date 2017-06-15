using SDMine.Collector.DataAccess;
using SDMine.Collector.Services.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace SDMine.Collector.Services
{
    public class PostLoader
    {
        List<FacebookPostItem> posts;

        DataTable dtPost = new DataTable();
        DataTable dtComment = new DataTable();
        DataTable dtShared = new DataTable();
        DataTable dtAttachment = new DataTable();
        DataTable dtPlace = new DataTable();
        DataTable dtProperty = new DataTable();
        DataTable dtTag = new DataTable();
        DataTable dtReaction = new DataTable();

        public PostLoader(List<FacebookPostItem> posts)
        {
            this.posts = posts;
            Prepare();
        }

        void Initialize()
        {
            InitializePost();
            InitializeComment();
            InitializeShared();
            InitializeAttachment();
            InitializePlace();
            InitializeProperty();
            InitializeTag();
            InitializeReaction();
        }

        void InitializePost()
        {
            dtPost.Columns.Add("id_first");
            dtPost.Columns.Add("id_last");
            dtPost.Columns.Add("caption");
            dtPost.Columns.Add("created_time", Type.GetType("System.DateTime"));
            dtPost.Columns.Add("description");
            dtPost.Columns.Add("fromID");
            dtPost.Columns.Add("full_picture");
            dtPost.Columns.Add("icon");
            dtPost.Columns.Add("is_expired");
            dtPost.Columns.Add("is_hidden");
            dtPost.Columns.Add("is_instagram_eligible");
            dtPost.Columns.Add("is_published");
            dtPost.Columns.Add("is_spherical");
            dtPost.Columns.Add("link");
            dtPost.Columns.Add("message");
            dtPost.Columns.Add("name");
            dtPost.Columns.Add("object_id");
            dtPost.Columns.Add("parent_id_first");
            dtPost.Columns.Add("parent_id_last");
            dtPost.Columns.Add("permalink_url");
            dtPost.Columns.Add("picture");
            dtPost.Columns.Add("PlaceID");
            dtPost.Columns.Add("LocationCity");
            dtPost.Columns.Add("LocationCountry");
            dtPost.Columns.Add("LocationLatitude");
            dtPost.Columns.Add("LocationLongitude");
            dtPost.Columns.Add("LocationStreet");
            dtPost.Columns.Add("LocationZIP");
            dtPost.Columns.Add("PrivacyValue");
            dtPost.Columns.Add("PrivacyDescription");
            dtPost.Columns.Add("PrivacyFriends");
            dtPost.Columns.Add("PrivacyAllow");
            dtPost.Columns.Add("PrivacyDeny");
            dtPost.Columns.Add("promotion_status");
            dtPost.Columns.Add("source");
            dtPost.Columns.Add("status_type");
            dtPost.Columns.Add("story");
            dtPost.Columns.Add("subscribed");
            dtPost.Columns.Add("timeline_visibility");
            dtPost.Columns.Add("type");
            dtPost.Columns.Add("updated_time");
            dtPost.Columns.Add("toID");
        }

        void InitializeComment()
        {
            dtComment.Columns.Add("id_first");
            dtComment.Columns.Add("id_last bigint");
            dtComment.Columns.Add("EntityTypeID");
            dtComment.Columns.Add("ParentIDFirst");
            dtComment.Columns.Add("ParentIDLast");
            dtComment.Columns.Add("created_time", Type.GetType("System.DateTime"));
            dtComment.Columns.Add("fromID");
            dtComment.Columns.Add("message");
        }

        void InitializeShared()
        {
            dtShared.Columns.Add("id_first");
            dtShared.Columns.Add("id_last");
            dtShared.Columns.Add("fromID");
            dtShared.Columns.Add("toID");
            dtShared.Columns.Add("created_time", Type.GetType("System.DateTime"));
        }

        void InitializeAttachment()
        {
            dtAttachment.Columns.Add("ID");
            dtAttachment.Columns.Add("EntityIDFirst");
            dtAttachment.Columns.Add("EntityIDLast");
            dtAttachment.Columns.Add("EntityTypeID");
            dtAttachment.Columns.Add("ParentID");
            dtAttachment.Columns.Add("description");
            dtAttachment.Columns.Add("title");
            dtAttachment.Columns.Add("type");
            dtAttachment.Columns.Add("url");
            dtAttachment.Columns.Add("ImageHeigh");
            dtAttachment.Columns.Add("ImageWidth");
            dtAttachment.Columns.Add("ImageSrc");
        }

        void InitializePlace()
        {
            dtPlace.Columns.Add("ID");
            dtPlace.Columns.Add("Name");
        }

        void InitializeProperty()
        {
            dtProperty.Columns.Add("EntityIDFirst");
            dtProperty.Columns.Add("EntityIDLast");
            dtProperty.Columns.Add("EntityTypeID");
            dtProperty.Columns.Add("Name");
            dtProperty.Columns.Add("Value");
        }

        void InitializeTag()
        {
            dtTag.Columns.Add("EntityIDFirst");
            dtTag.Columns.Add("EntityIDLast");
            dtTag.Columns.Add("EntityTypeID");
            dtTag.Columns.Add("AccountID");
        }

        void InitializeReaction()
        {
            dtReaction.Columns.Add("EntityIDFirst");
            dtReaction.Columns.Add("EntityIDLast");
            dtReaction.Columns.Add("EntityTypeID");
            dtReaction.Columns.Add("TypeID");
            dtReaction.Columns.Add("AccountID");
        }

        void Prepare()
        {
            Initialize();

            foreach (var p in posts)
            {
                dtPost.Rows.Add(GetIDFirst(p.id),
                                GetIDLast(p.id),
                                p.caption,
                                p.created_time,
                                p.description,
                                p.from.ID,
                                p.full_picture,
                                p.icon,
                                p.is_expired,
                                p.is_hidden,
                                p.is_instagram_eligible,
                                p.is_published,
                                p.is_spherical,
                                p.link,
                                p.message,
                                p.object_id,
                                GetIDFirst(p.parent_id),
                                GetIDLast(p.parent_id),
                                p.permalink_url,
                                p.picture,
                                p.place != null ? (long?)p.place.id : null,
                                p.place != null && p.place.location != null ? p.place.location.city : null,
                                p.place != null && p.place.location != null ? p.place.location.country : null,
                                p.place != null && p.place.location != null ? p.place.location.latitude : null,
                                p.place != null && p.place.location != null ? p.place.location.longitude : null,
                                p.place != null && p.place.location != null ? p.place.location.street : null,
                                p.place != null && p.place.location != null ? p.place.location.zip : null,
                                p.privacy != null ? p.privacy.value : null,
                                p.privacy != null ? p.privacy.description : null,
                                p.privacy != null ? p.privacy.friends : null,
                                p.privacy != null ? p.privacy.allow : null,
                                p.privacy != null ? p.privacy.deny : null,
                                p.promotion_status,
                                p.source,
                                p.status_type,
                                p.story,
                                p.subscribed,
                                p.timeline_visibility,
                                p.type,
                                p.updated_time,
                                p.to != null && p.to.Data.FirstOrDefault() != null ? (long?)p.to.Data.FirstOrDefault().id : null);

                AddComments(p);
                AddSharedPosts(p);
                AddAttachments(p);
                AddProperties(p);
                AddTags(p.message_tags, p.id, Types.MessageOfPost);
                AddTags(p.story_tags, p.id, Types.StoryOfPost);
                AddReactions(p.reactions.Data, p.id, Types.Post);
            }

            PreparePlaces();
        }

        void AddComments(FacebookPostItem p)
        {
            foreach (var c in p.comments.Data)
            {
                AddComments(c, null);

                if (c.comments != null)
                {
                    foreach (var sc in c.comments.Data)
                        AddComments(sc, c.id);
                }
            }
        }

        void AddComments(FacebookCommentItem c, string parentID)
        {
            int TypeID = parentID == null ? Types.PostComment : Types.PostSubComment;
            int TagTypeID = parentID == null ? Types.MessageOfPostComment : Types.MessageOfPostSubComment;

            dtComment.Rows.Add(GetIDFirst(c.id),
                               GetIDLast(c.id),
                               TypeID,
                               GetIDFirst(parentID),
                               GetIDLast(parentID),
                               c.created_time,
                               c.from != null ? (long?)c.from.ID : null,
                               c.message);

            AddTags(c.message_tags, c.id, TagTypeID);

            if (c.reactions != null)
            {
                AddReactions(c.reactions.Data, c.id, TypeID);
            }
        }

        void AddSharedPosts(FacebookPostItem p)
        {
            if (p.sharedposts == null)
            {
                return;
            }

            foreach (var s in p.sharedposts.Data)
            {
                var to = s.to != null && s.to.Data != null ? s.to.Data.FirstOrDefault() : null;
                var toId = to != null ? to.id : (long?)null;
                dtShared.Rows.Add(GetIDFirst(p.id),
                                  GetIDLast(p.id),
                                  s.from.ID,
                                  toId,
                                  s.created_time);
            }
        }

        void AddAttachments(FacebookPostItem p)
        {
            if (p.attachments == null)
            {
                return;
            }

            AddAttachments(p.attachments.Data, p);
        }

        void AddAttachments(List<FacebookAttachmentItem> attachments, FacebookPostItem post, Guid? parentID = null)
        {
            foreach (var a in attachments)
            {
                var attachmentID = Guid.NewGuid();
                dtAttachment.Rows.Add(attachmentID,
                                      GetIDFirst(post.id),
                                      GetIDLast(post.id),
                                      parentID == null ? Types.PostAttachment : Types.PostSubAttachment,
                                      parentID,
                                      a.description,
                                      a.title,
                                      a.type,
                                      a.url,
                                      a.media != null && a.media.image != null ? (int?)a.media.image.height : null,
                                      a.media != null && a.media.image != null ? (int?)a.media.image.width : null,
                                      a.media != null && a.media.image != null ? a.media.image.src : null);
                //AddTags(a.description_tags, Types.DescriptionOfPostAttachment);       //TODO: need to have ID as long

                if (a.subattachments != null)
                {
                    AddAttachments(a.subattachments.Data, post, attachmentID);
                }
            }
        }

        void AddProperties(FacebookPostItem p)
        {
            if (p.properties == null)
            {
                return;
            }

            foreach (var item in p.properties)
            {
                dtProperty.Rows.Add(GetIDFirst(p.id),
                                    GetIDLast(p.id),
                                    Types.Post,
                                    item.name,
                                    item.text);
            }
        }

        void AddTags(List<FacebookTagItem> tags, string id, int TypeID)
        {
            if (tags == null)
            {
                return;
            }

            foreach (var t in tags)
            {
                dtTag.Rows.Add(GetIDFirst(id),
                               GetIDLast(id),
                               TypeID,
                               t.id);
            }
        }

        void AddReactions(List<FacebookReactionItem> reactions, string id, int TypeID)
        {
            if (reactions == null)
            {
                return;
            }

            foreach (var r in reactions)
            {
                dtReaction.Rows.Add(GetIDFirst(id),
                                    GetIDLast(id),
                                    TypeID,
                                    r.type,
                                    r.id);
            }
        }

        long? GetIDFirst(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }

            var ids = id.Split('_');
            if (ids.Length == 0)
            {
                return null;
            }

            long tmpId;
            if (long.TryParse(id.Split('_')[0], out tmpId))
            {
                return tmpId;
            }

            return null;
        }

        long? GetIDLast(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }

            var ids = id.Split('_');
            if (ids.Length == 0)
            {
                return null;
            }

            long tmpId;
            if (long.TryParse(id.Split('_')[1], out tmpId))
            {
                return tmpId;
            }

            return null;
        }

        void PreparePlaces()
        {
            Dictionary<long, string> places = new Dictionary<long, string>();
            foreach (var p in posts)
            {
                if ((p.place != null) && (places.ContainsKey(p.place.id)))
                    places.Add(p.place.id, p.place.name);
            }

            foreach (var p in places)
            {
                dtPlace.Rows.Add(p.Key, p.Value);
            }
        }

        public void Save()
        {
            SqlParameter pPosts = new SqlParameter("posts", SqlDbType.Structured);
            pPosts.Value = dtPost;
            pPosts.TypeName = "dbo.tPost";

            SqlParameter pComments = new SqlParameter("comments", SqlDbType.Structured);
            pComments.Value = dtComment;
            pComments.TypeName = "dbo.tComment";

            SqlParameter pShared = new SqlParameter("shared", SqlDbType.Structured);
            pShared.Value = dtPost;
            pShared.TypeName = "dbo.tSharedPost";

            SqlParameter pAttachments = new SqlParameter("attachments", SqlDbType.Structured);
            pAttachments.Value = dtAttachment;
            pAttachments.TypeName = "dbo.tAttachment";

            SqlParameter pPlaces = new SqlParameter("places", SqlDbType.Structured);
            pPlaces.Value = dtPlace;
            pPlaces.TypeName = "dbo.tPlace";

            SqlParameter pProperties = new SqlParameter("properties", SqlDbType.Structured);
            pProperties.Value = dtProperty;
            pProperties.TypeName = "dbo.tProperty";

            SqlParameter pTags = new SqlParameter("tags", SqlDbType.Structured);
            pTags.Value = dtTag;
            pTags.TypeName = "dbo.tTag";

            SqlParameter pReaction = new SqlParameter("reactions", SqlDbType.Structured);
            pReaction.Value = dtReaction;
            pReaction.TypeName = "dbo.tReaction";

            using (var conn = DbContext.CreateConnection())
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "AddPosts";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(pPosts);
                    cmd.Parameters.Add(pComments);
                    cmd.Parameters.Add(pShared);
                    cmd.Parameters.Add(pAttachments);
                    cmd.Parameters.Add(pPlaces);
                    cmd.Parameters.Add(pProperties);
                    cmd.Parameters.Add(pTags);
                    cmd.Parameters.Add(pReaction);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
