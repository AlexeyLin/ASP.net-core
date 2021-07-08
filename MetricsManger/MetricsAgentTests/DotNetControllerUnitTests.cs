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
    public class DotNetControllerUnitTests
    {
        private readonly DotNetMetricsController _controller;
        private readonly Mock<IDotNetMetricsRepository> _mock;
        private readonly Mock<ILogger<DotNetMetricsController>> _mockLog;

        public DotNetControllerUnitTests()
        {
            _mock = new Mock<IDotNetMetricsRepository>();
            _mockLog = new Mock<ILogger<DotNetMetricsController>>();
            _controller = new DotNetMetricsController(_mockLog.Object, _mock.Object);
        }

        [Fact]
        public void Create_ReturnsOk()
        {
            _mock.Setup(repository => repository.Create(It.IsAny<DotNetMetric>())).Verifiable();

            var result = _controller.Create(new MetricsAgent.Requests.DotNetMetricCreateRequest { Time = DateTimeOffset.FromUnixTimeSeconds(0), Value = 50 });

            _mock.Verify(repository => repository.Create(It.IsAny<DotNetMetric>()), Times.Once());
        }

        [Fact]
        public void GetMetrics_ReturnsOk()
        {
            var fromTime = DateTimeOffset.FromUnixTimeSeconds(0);
            var toTime = DateTimeOffset.FromUnixTimeSeconds(100);

            _mock.Setup(repository => repository.GetByTimePeriod(fromTime, toTime)).Returns(new List<DotNetMetric>());

            var result = _controller.GetErrorsCount(fromTime, toTime);

            _mock.Verify(repository => repository.GetByTimePeriod(fromTime, toTime), Times.Once());
        }
    }
}
