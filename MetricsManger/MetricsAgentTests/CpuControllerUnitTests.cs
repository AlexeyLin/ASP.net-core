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
    public class CpuControllerUnitTests
    {
        private CpuMetricsController _controller;
        private Mock<ICpuMetricsRepository> _mock;
        private Mock<ILogger<CpuMetricsController>> _mockLog;

        public CpuControllerUnitTests()
        {
            _mock = new Mock<ICpuMetricsRepository>();
            _mockLog = new Mock<ILogger<CpuMetricsController>>();
            _controller = new CpuMetricsController(_mockLog.Object, _mock.Object);
        }

        [Fact]
        public void Create_ReturnsOk()
        {
            _mock.Setup(repository => repository.Create(It.IsAny<CpuMetric>())).Verifiable();

            var result = _controller.Create(new MetricsAgent.Requests.CpuMetricCreateRequest { Time = DateTimeOffset.FromUnixTimeSeconds(0), Value = 50 });

            _mock.Verify(repository => repository.Create(It.IsAny<CpuMetric>()), Times.Once());
        }

        [Fact]
        public void GetMetrics_ReturnsOk()
        {
            var fromTime = DateTimeOffset.FromUnixTimeSeconds(0);
            var toTime = DateTimeOffset.FromUnixTimeSeconds(100);

            _mock.Setup(repository => repository.GetByTimePeriod(fromTime, toTime)).Returns(new List<CpuMetric>());

            var result = _controller.GetMetrics(fromTime, toTime);

            _mock.Verify(repository => repository.GetByTimePeriod(fromTime, toTime), Times.Once());
        }
    }
}
