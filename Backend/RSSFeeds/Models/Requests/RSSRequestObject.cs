using Newtonsoft.Json;

namespace RSSFeeds.Models.Requests
{
    public class RSSRequestObject
    {
        [JsonProperty("Word")]
        public string Word { get; set; }

    }
}
