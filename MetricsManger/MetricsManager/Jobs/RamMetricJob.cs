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

        public RamMetricJob(IRamMetricsRepository repository)
        {
            _repository = repository;
        }

        public Task Execute(IJobExecutionContext context)
        {

            return Task.CompletedTask;
        }
    }
}