using System.Collections.Generic;

namespace SDMine.Collector.Services
{
    public class FacebookApiRequest
    {
        private readonly string _baseUri;
        private readonly string _pageId;
        private readonly string _accessToken;

        public List<string> Fields { get; set; }
        public int Limit { get; set; }

        public FacebookApiRequest(string baseUri, string pageId, string accessToken)
        {
            _baseUri = baseUri;
            _pageId = pageId;
            _accessToken = accessToken;
        }

        public string GetUri()
        {
            var fields = string.Join(",", Fields);
            var uri = $"{_baseUri}{_pageId}/feed?fields={fields}&access_token={_accessToken}";
            return uri;
        }
    }
}
