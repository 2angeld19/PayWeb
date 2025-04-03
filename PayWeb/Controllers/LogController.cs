using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PayWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogController : ControllerBase
    {
        private readonly ILogger<LogController> _logger;

        public LogController(ILogger<LogController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Log([FromBody] LogMessage logMessage)
        {
            _logger.LogError("JavaScript Error: {Message}\nStack: {Stack}", logMessage.Message, logMessage.Stack);
            return Ok();
        }
    }

    public class LogMessage
    {
        public string? Message { get; set; }
        public string? Stack { get; set; }
    }
}

