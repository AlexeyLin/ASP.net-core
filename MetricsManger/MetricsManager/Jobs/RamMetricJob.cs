using Quartz;
using System;
using System.Threading.Tasks;
using MetricsManager.DAL.Interfaces;
using MetricsManager.DAL.Models;

namespace MetricsManager.Jobs
{
    public class RamMetricJob : IJob
    {
        private IRamMetricsRepository _repository;

        private PerformanceCounter _ramCounter;

        public RamMetricJob(IRamMetricsRepository repository)
        {
            _repository = repository;
            _ramCounter = new PerformanceCounter("Memory", "Available MBytes");
        }

        public Task Execute(IJobExecutionContext context)
        {
            var ramAvailableMBytes = Convert.ToInt32(_ramCounter.NextValue());

            var time = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

            _repository.Create(new RamMetric { Time = time, Value = ramAvailableMBytes });

            return Task.CompletedTask;
        }
    }
}