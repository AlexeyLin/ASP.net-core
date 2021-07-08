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
    public class NetworkControllerUnitTests
    {
        private readonly NetworkMetricsController _controller;
        private readonly Mock<INetworkMetricsRepository> _mock;
        private readonly Mock<ILogger<NetworkMetricsController>> _mockLog;

        public NetworkControllerUnitTests()
        {
            _mock = new Mock<INetworkMetricsRepository>();
            _mockLog = new Mock<ILogger<NetworkMetricsController>>();
            _controller = new NetworkMetricsController(_mockLog.Object, _mock.Object);
        }

        [Fact]
        public void Create_ReturnsOk()
        {
            _mock.Setup(repository => repository.Create(It.IsAny<NetworkMetric>())).Verifiable();

            var result = _controller.Create(new MetricsAgent.Requests.NetworkMetricCreateRequest { Time = DateTimeOffset.FromUnixTimeSeconds(0), Value = 50 });

            _mock.Verify(repository => repository.Create(It.IsAny<NetworkMetric>()), Times.Once());
        }

        [Fact]
        public void GetMetrics_ReturnsOk()
        {
            var fromTime = DateTimeOffset.FromUnixTimeSeconds(0);
            var toTime = DateTimeOffset.FromUnixTimeSeconds(100);

            _mock.Setup(repository => repository.GetByTimePeriod(fromTime, toTime)).Returns(new List<NetworkMetric>());

            var result = _controller.GetMetrics(fromTime, toTime);

            _mock.Verify(repository => repository.GetByTimePeriod(fromTime, toTime), Times.Once());
        }
    }
}