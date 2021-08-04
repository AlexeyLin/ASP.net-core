using MetricsManager.DAL;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using MetricsManager.DAL.Interfaces;
using MetricsManager.DAL.Models;

namespace MetricsManager.Jobs
{
    public class HddMetricJob : IJob
    {
        private IHddMetricsRepository _repository;


        public HddMetricJob(IHddMetricsRepository repository)
        {
            _repository = repository;
            
        }

        public Task Execute(IJobExecutionContext context)
        {
            

            return Task.CompletedTask;
        }
    }
}