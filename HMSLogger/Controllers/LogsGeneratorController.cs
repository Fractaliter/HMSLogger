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
        private LogWorkerService _logservice;
        private CancellationToken stoppingToken;
        public LogsGeneratorController(ILogger<LogsGeneratorController> logger)
        {
            _logger = logger;
            _logservice = new LogWorkerService();
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            stoppingToken = cancelTokenSource.Token;
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

            _logger.LogInformation("visited page at {DT}", DateTime.UtcNow.ToLongTimeString());
            LogsGenerator.Add("visited page at " + DateTime.UtcNow.ToLongTimeString());



            return LogsGenerator.GetList();
        }
    }
}
