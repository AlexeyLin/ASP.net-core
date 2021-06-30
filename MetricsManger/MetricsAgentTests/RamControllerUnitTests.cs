using MetricsAgent.Controllers;
using MetricsAgent;
using System;
using Xunit;
using Microsoft.AspNetCore.Mvc;

namespace MetricsAgentTests
{
    public class RamControllerUnitTests
    {
        private RamMetricsController controller;

        public RamControllerUnitTests()
        {
            controller = new RamMetricsController();
        }

        [Fact]
        public void GetAvailableRam_ReturnsOk()
        {
            //Arrange
            var fromTime = new DateTimeOffset();
            var toTime = new DateTimeOffset();

            //Act
            var result = controller.GetAvailableRam(fromTime, toTime);

            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
