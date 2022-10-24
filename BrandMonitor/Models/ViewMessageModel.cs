using BrandMonitor.Data;
using BrandMonitor.Service;

namespace BrandMonitor.Models
{
    public class ViewMessageModel
    {
        private DataService dataService;
        private IConfiguration configuration;
        public Message Message { get; set; }
        public IEnumerable<BrandMonitor.Data.Topic> Topics { get; set; }

        public ViewMessageModel(DataService dataService, IConfiguration configuration, long id)
        {
            this.dataService = dataService;
            this.configuration = configuration;
            GetData(id);
        }

        private void GetData(long id)
        {
            Message = dataService.GetMessage(id);
            if(!Message.Sentiment.HasValue)
            {
                dataService.GetSentiment(configuration, id);
                Message = dataService.GetMessage(id);
            }
            Topics = dataService.GetTopics(id);
        }
    }
}
