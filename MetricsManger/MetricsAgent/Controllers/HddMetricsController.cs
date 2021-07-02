using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using MetricsAgent.DAL.Interfaces;
using MetricsAgent.DAL.Models;
using MetricsAgent.Requests;
using MetricsAgent.Responses;

namespace MetricsAgent.Controllers
{
    [Route("api/metrics/hdd")]
    [ApiController]
    public class HddMetricsController : ControllerBase
    {
        private readonly IHddMetricsRepository _repository;

        private readonly ILogger<HddMetricsController> _logger;

        public HddMetricsController(ILogger<HddMetricsController> logger, IHddMetricsRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet("left/from/{fromTime}/to/{toTime}")]
        public IActionResult GetLeftCapacity([FromRoute] DateTimeOffset fromTime, [FromRoute] DateTimeOffset toTime)
        {
            _logger.LogInformation("GetLeftCapacity fromTime:{0} toTime:{1}", fromTime, toTime);

            var metrics = _repository.GetByTimePeriod(fromTime, toTime);
            var response = new AllHddMetricsResponse()
            {
                Metrics = new List<HddMetricDto>()
            };

            foreach (var metric in metrics)
            {
                response.Metrics.Add(new HddMetricDto
                {
                    Time = DateTimeOffset.FromUnixTimeSeconds(metric.Time),
                    Value = metric.Value,
                    Id = metric.Id
                });
            }

            return Ok(response);
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] HddMetricCreateRequest request)
        {
            _repository.Create(new HddMetric
            {
                Time = request.Time.ToUnixTimeSeconds(),
                Value = request.Value
            });

            return Ok();
        }
    }
}
