using BrandMonitor.Models;
using BrandMonitor.Service;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BrandMonitor.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private DataService _dataService;
        private IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, DataService dataService, IConfiguration configuration)
        {
            _logger = logger;
            _dataService = dataService;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ListMessages(string topic)
        {
            ListMessagesViewModel model = new ListMessagesViewModel(_dataService);


            if (!string.IsNullOrWhiteSpace(topic))
            {
                model.Messages = model.Topics.Where(y => y.Label == topic).Select(x => x.Message);
                var sentiment = (model.Messages.Average(x => x.Sentiment));

                model.Sentiment = sentiment;
            }
            return View(model);
        }

        public IActionResult ViewMessage(long id)
        {
            ViewMessageModel model = new ViewMessageModel(_dataService, _configuration, id);
            return View(model);
        }
    }
}