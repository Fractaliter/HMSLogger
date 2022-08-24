using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HMSLogger.Services
{
    public class LogWorkerService : IHostedService, IDisposable
    {

        private Timer? _timer = null;


        public Task StartAsync(CancellationToken stoppingToken)
        {
            LogsGenerator.Add("Timed Hosted Service started " + DateTime.UtcNow.ToLongTimeString());

            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(5));

            return Task.CompletedTask;
        }

        private void DoWork(object? state)
        {

            LogsGenerator.Add( "Timed Hosted Service is working " + DateTime.UtcNow.ToLongTimeString());
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
