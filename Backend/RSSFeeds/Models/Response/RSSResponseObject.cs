using Newtonsoft.Json;

namespace RSSFeeds.Models.Response
{
    public class RSSResponseObject
    {
        [JsonProperty("Word")]
        public string Word { get; set; }

        [JsonProperty("Stats")]
        public List<int> Counts { get; set; }

    }

    

}
