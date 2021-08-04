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
    public class CpuMetricJob : IJob
    {
        private ICpuMetricsRepository _repository;

        public CpuMetricJob(ICpuMetricsRepository repository)
        {
            _repository = repository;
            
        }

        public Task Execute(IJobExecutionContext context)
        {
            

            return Task.CompletedTask;
        }
    }
}

