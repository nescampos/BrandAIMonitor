using BrandMonitor.Data;
using BrandMonitor.Service;

namespace BrandMonitor.Models
{
    public class ListMessagesViewModel
    {
        private DataService dataService;
        public decimal? Sentiment { get; set; }
        public IEnumerable<Message> Messages { get; set; }
        public IEnumerable<BrandMonitor.Data.Topic> Topics { get; set; }

        public ListMessagesViewModel(DataService dataService)
        {
            this.dataService = dataService;
            CalculateSentiment();
        }

        public void CalculateSentiment()
        {
            Messages = dataService.GetMessages();
            Sentiment = Messages.Average(x => x.Sentiment);
            Topics = dataService.GetTopics();
        }
    }
}
