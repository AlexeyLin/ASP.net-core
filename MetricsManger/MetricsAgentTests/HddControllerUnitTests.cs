using MetricsAgent.Controllers;
using System;
using Xunit;
using Moq;
using MetricsAgent.DAL.Interfaces;
using MetricsAgent.DAL.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace MetricsAgentTests
{
    public class HddControllerUnitTests
    {
        private readonly HddMetricsController _controller;
        private readonly Mock<IHddMetricsRepository> _mock;
        private readonly Mock<ILogger<HddMetricsController>> _mockLog;

        public HddControllerUnitTests()
        {
            _mock = new Mock<IHddMetricsRepository>();
            _mockLog = new Mock<ILogger<HddMetricsController>>();
            _controller = new HddMetricsController(_mockLog.Object, _mock.Object);
        }

        [Fact]
        public void Create_ReturnsOk()
        {
            _mock.Setup(repository => repository.Create(It.IsAny<HddMetric>())).Verifiable();

            var result = _controller.Create(new MetricsAgent.Requests.HddMetricCreateRequest { Time = DateTimeOffset.FromUnixTimeSeconds(0), Value = 50 });

            _mock.Verify(repository => repository.Create(It.IsAny<HddMetric>()), Times.Once());
        }

        [Fact]
        public void GetMetrics_ReturnsOk()
        {
            var fromTime = DateTimeOffset.FromUnixTimeSeconds(0);
            var toTime = DateTimeOffset.FromUnixTimeSeconds(100);

            _mock.Setup(repository => repository.GetByTimePeriod(fromTime, toTime)).Returns(new List<HddMetric>());

            var result = _controller.GetLeftCapacity(fromTime, toTime);

            _mock.Verify(repository => repository.GetByTimePeriod(fromTime, toTime), Times.Once());
        }
    }
}
