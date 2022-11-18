using Microsoft.AspNetCore.Mvc;

namespace SsampleOpenTelemetryApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DistributedTracingController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<DistributedTracingController> _logger;

        public DistributedTracingController(ILogger<DistributedTracingController> logger)
        {
            _logger = logger;
        }

        [HttpGet("Success")]
        public ActionResult Get()
        {
            _logger.LogInformation("Testing OpenTelemetry");
            return Ok("Success");
        }

        [HttpGet("Error")]
        public ActionResult GetWithError()
        {
            _logger.LogError("Testing OpenTelemetry With Error");
            throw new Exception("Testing OpenTelemetry With Error");
        }

    }
}