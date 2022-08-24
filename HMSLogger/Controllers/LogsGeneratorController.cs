using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using HMSLogger.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HMSLogger.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogsGeneratorController : ControllerBase
    {


        private readonly ILogger<LogsGeneratorController> _logger;
        public LogsGeneratorController(ILogger<LogsGeneratorController> logger)
        {
            _logger = logger;
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
        }

        [HttpGet]
        public List<String> GetLogs()
        {

            _logger.LogInformation("visited page at {DT}", DateTime.UtcNow.ToLongTimeString());
            LogsGenerator.Add("visited page at "+ DateTime.UtcNow.ToLongTimeString());



            return LogsGenerator.GetList();
        }
        [HttpGet("{id}")]
        public List<String> GetAmountOfLogs(int id)
        {

            _logger.LogInformation("GetAmountOfLog {DT}", DateTime.UtcNow.ToLongTimeString());
            LogsGenerator.Add("GetAmountOfLog at " + DateTime.UtcNow.ToLongTimeString());



            return LogsGenerator.GeAmountofList(id);
        }
    }
}
