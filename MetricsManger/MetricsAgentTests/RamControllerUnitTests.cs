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
    public class RamControllerUnitTests
    {
        private readonly RamMetricsController _controller;
        private readonly Mock<IRamMetricsRepository> _mock;
        private readonly Mock<ILogger<RamMetricsController>> _mockLog;

        public RamControllerUnitTests()
        {
            _mock = new Mock<IRamMetricsRepository>();
            _mockLog = new Mock<ILogger<RamMetricsController>>();
            _controller = new RamMetricsController(_mockLog.Object, _mock.Object);
        }

        [Fact]
        public void Create_ReturnsOk()
        {
            _mock.Setup(repository => repository.Create(It.IsAny<RamMetric>())).Verifiable();

            var result = _controller.Create(new MetricsAgent.Requests.RamMetricCreateRequest { Time = DateTimeOffset.FromUnixTimeSeconds(0), Value = 50 });

            _mock.Verify(repository => repository.Create(It.IsAny<RamMetric>()), Times.Once());
        }

        [Fact]
        public void GetMetrics_ReturnsOk()
        {
            var fromTime = DateTimeOffset.FromUnixTimeSeconds(0);
            var toTime = DateTimeOffset.FromUnixTimeSeconds(100);

            _mock.Setup(repository => repository.GetByTimePeriod(fromTime, toTime)).Returns(new List<RamMetric>());

            var result = _controller.GetAvailableRam(fromTime, toTime);

            _mock.Verify(repository => repository.GetByTimePeriod(fromTime, toTime), Times.Once());
        }
    }
}
