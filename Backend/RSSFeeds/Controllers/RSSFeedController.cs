using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RSSFeeds.Models.Requests;
using RSSFeeds.Models.Response;
using System.ServiceModel;
using System.ServiceModel.Syndication;
using System.Xml;

namespace RSSFeeds.Controllers
{

    [ApiController]
    [Route("api")]
    public class RSSFeedController : ControllerBase
    {

        public static readonly List<string> list = new List<string>() { "https://tribune.com.pk/feed/world", "https://nation.com.pk/rss/international" };
        private readonly ILogger<RSSFeedController> _logger;

        public RSSFeedController(ILogger<RSSFeedController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("GetTrendValues")]
        public RSSResponseObject Get(RSSRequestObject request)
        {

            request.Word = request.Word.Trim();
            var response = new RSSResponseObject();
            response.Counts = new List<int>();
            response.Word = request.Word;
            var countList = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 ,0, 0, 0, 0};
            foreach (var url in list) { 
            
                var responseObject = new RSSResponseObject();
                XmlReader reader = XmlReader.Create(url);
                SyndicationFeed feed = SyndicationFeed.Load(reader);
                reader.Close();
                foreach (var item in feed.Items) {

                    if (item.Content == null)
                    {
                        if (item.Title.Text.Contains(request.Word, StringComparison.InvariantCultureIgnoreCase) == true)
                        {
                            var index = item.PublishDate.Month - 1;
                            countList[index] = countList[index] + 1;


                        }
                    }
                    else {

                        Console.WriteLine(item.Content);

                    }


                }

                
            
            }

            response.Counts.AddRange(countList);


            return response;

        }


        


    }
}