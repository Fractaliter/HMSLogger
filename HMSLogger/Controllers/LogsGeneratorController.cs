using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HMSLogger.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogsGeneratorController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Penis", "Dupoa", "Kuba", "Ma", "Malego", "Smartfona", "Robmy", "Ten", "Projekt"
        };

        private readonly ILogger<LogsGeneratorController> _logger;

        public LogsGeneratorController(ILogger<LogsGeneratorController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<LogsGenerator> Get(int id)
        {
            var rng = new Random();

            _logger.LogInformation("visited page at {DT}", DateTime.UtcNow.ToLongTimeString());


            var loginfo = Enumerable.Range(1, 5).Select(index => new LogsGenerator
            {
                Date = DateTime.UtcNow,
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });


            _logger.LogInformation(loginfo.ToString());

            return Enumerable.Range(1, 5).Select(index => new LogsGenerator
            {
                Date = DateTime.UtcNow,
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray(); 
        }
    }
}
