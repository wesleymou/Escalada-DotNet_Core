using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Escalada.Controllers
{
    public class EventController : Controller
    {
        private readonly ILogger<EventController> _logger;
        public EventController(ILogger<EventController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}