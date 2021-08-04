using Quartz;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using MetricsManager.DAL.Interfaces;
using MetricsManager.DAL.Models;

namespace MetricsManager.Jobs
{
    public class DotNetMetricJob : IJob
    {
        private IDotNetMetricsRepository _repository;

        private PerformanceCounter _dotNetCounter;

        public DotNetMetricJob(IDotNetMetricsRepository repository)
        {
            _repository = repository;
            _dotNetCounter = new PerformanceCounter("ASP.NET Applications", "Errors Total", "__Total__");
        }

        public Task Execute(IJobExecutionContext context)
        {
            var errorsCountDotNet = Convert.ToInt32(_dotNetCounter.NextValue());

            var time = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

            _repository.Create(new DotNetMetric { Time = time, Value = errorsCountDotNet });

            return Task.CompletedTask;
        }
    }
}
