﻿using MetricsManager.DAL;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System;
using System.Diagnostics;
using System.Security.Policy;
using System.Threading.Tasks;
using MetricsManager.Client;
using MetricsManager.DAL.Interfaces;
using MetricsManager.DAL.Models;
using MetricsManager.Requests;

namespace MetricsManager.Jobs
{
    public class HddMetricJob : IJob
    {
        private IHddMetricsRepository _metricsRepository;

        private IAgentsRepository _agentRepository;

        private IMetricsAgentClient _metricClient;

        private HddMetricJob(IHddMetricsRepository metricsRepository, IAgentsRepository agentRepository, IMetricsAgentClient metricClient)
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
                var metrics = _metricClient.GetHddMetrics(new HddMetricApiRequest
                {
                    ClientBaseAddress = new Url(agent.Address),
                    FromTime = DateTimeOffset.FromUnixTimeSeconds(fromTime),
                    ToTime = toTime
                });

                if (metrics != null)
                {
                    foreach (var metric in metrics.Metrics)
                    {
                        _metricsRepository.Create(new HddMetric
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