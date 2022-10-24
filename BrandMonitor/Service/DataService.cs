using BrandMonitor.Data;
using BrandMonitor.Models;
using Newtonsoft.Json;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace BrandMonitor.Service
{
    public class DataService
    {
        private ApplicationDbContext _db { get; set; }
        public DataService(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Message> GetMessages()
        {
            return _db.Messages.OrderByDescending(x => x.CreatedAt);
        }

        public Message GetMessage(long id)
        {
            return _db.Messages.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<BrandMonitor.Data.Topic> GetTopics()
        {
            return _db.Topics.OrderBy(x => x.Label);
        }

        public IEnumerable<BrandMonitor.Data.Topic> GetTopics(long id)
        {
            return _db.Topics.Include(x => x.Message).Where(x => x.MessageId == id).OrderByDescending(x => x.Score);
        }

        public void GetSentiment(IConfiguration configuration, long id)
        {
            Message message = GetMessage(id);
            string token = string.Empty;
            var urlToken = "https://developer.expert.ai/oauth2/token";
            var json = JsonConvert.SerializeObject(new { username = configuration["ExpertAIUser"], password = configuration["ExpertAIPassword"] });
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            using (var client = new HttpClient())
            {
                //client.DefaultRequestHeaders.Add("Content-Type", "application/json; charset=utf-8");
                var response = client.PostAsync(urlToken, data).Result;

                token = response.Content.ReadAsStringAsync().Result;
            }

            var urlAnalysis = "https://nlapi.expert.ai/v2/analyze/standard/en";
            var jsonAnalysis = JsonConvert.SerializeObject(new { document = new { text = message.Text } });
            var dataAnalysis = new StringContent(jsonAnalysis, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                //client.DefaultRequestHeaders.Add("Content-Type", "application/json; charset=utf-8");
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                var response = client.PostAsync(urlAnalysis, dataAnalysis).Result;

                string result = response.Content.ReadAsStringAsync().Result;

                var respuesta = JsonConvert.DeserializeObject<ExpertAnalysisResponse>(result);
                if (respuesta != null && respuesta.success)
                {
                    message.Sentiment = respuesta.data.sentiment.overall;
                    
                    if (respuesta.data.topics != null && respuesta.data.topics.Any())
                    {
                        var newTopics = respuesta.data.topics.Select(x => new BrandMonitor.Data.Topic { Label = x.label, MessageId = message.Id, Score = x.score, Winner = x.winner });
                        _db.Topics.AddRange(newTopics);
                    }
                }
                _db.SaveChanges();
            }
        }
    }
}
