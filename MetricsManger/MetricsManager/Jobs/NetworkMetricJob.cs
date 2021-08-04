using Quartz;
using System;
using System.Threading.Tasks;
using MetricsManager.DAL.Interfaces;
using MetricsManager.DAL.Models;

namespace MetricsManager.Jobs
{
    public class NetworkMetricJob : IJob
    {
        private INetworkMetricsRepository _repository;

        private PerformanceCounter _networkCounter;

        public NetworkMetricJob(INetworkMetricsRepository repository)
        {
            _repository = repository;
            _networkCounter = new PerformanceCounter("Network Interface", "Packets/sec", "Intel[R] Ethernet Connection [2] I219-V _2");
        }

        public Task Execute(IJobExecutionContext context)
        {
            var networkPacketsInSec = Convert.ToInt32(_networkCounter.NextValue());

            var time = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

            _repository.Create(new NetworkMetric { Time = time, Value = networkPacketsInSec });

            return Task.CompletedTask;
        }
    }
}
