using Quartz;
using System;
using System.Security.Policy;
using System.Threading.Tasks;
using MetricsManager.Client;
using MetricsManager.DAL.Interfaces;
using MetricsManager.DAL.Models;
using MetricsManager.Requests;

namespace MetricsManager.Jobs
{
    public class RamMetricJob : IJob
    {
        private IRamMetricsRepository _metricsRepository;

        private IAgentsRepository _agentRepository;

        private IMetricsAgentClient _metricClient;

        private RamMetricJob(IRamMetricsRepository metricsRepository, IAgentsRepository agentRepository, IMetricsAgentClient metricClient)
        {
            _metricsRepository = metricsRepository;
            _agentRepository = agentRepository;
            _metricClient = metricClient;
        }

        public Task Execute(IJobExecutionContext context)
        {
            var agents = _agentRepository.GetListRegisterAgents();
            foreach (var agent in agents)
            {
                var fromTime = _metricsRepository.GetLastTime(agent.Id);
                var toTime = DateTimeOffset.UtcNow;
                var metrics = _metricClient.GetRamMetrics(new RamMetricApiRequest
                {
                    ClientBaseAddress = new Url(agent.Address),
                    FromTime = DateTimeOffset.FromUnixTimeSeconds(fromTime),
                    ToTime = toTime
                });

                if (metrics != null)
                {
                    foreach (var metric in metrics.Metrics)
                    {
                        _metricsRepository.Create(new RamMetric
                        {
                            AgentId = agent.Id,
                            Time = metric.Time.ToUnixTimeSeconds(),
                            Value = metric.Value,
                        });
                    }
                }
            }

            return Task.CompletedTask;
        }
    }
}