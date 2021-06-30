using MetricsAgent.Controllers;
using MetricsAgent;
using System;
using Xunit;
using Microsoft.AspNetCore.Mvc;

namespace MetricsAgentTests
{
    public class HddControllerUnitTests
    {
        private HddMetricsController controller;

        public HddControllerUnitTests()
        {
            controller = new HddMetricsController();
        }

        [Fact]
        public void GetLeftCapacity_ReturnsOk()
        {
            //Arrange
            var fromTime = new DateTimeOffset();
            var toTime = new DateTimeOffset();

            //Act
            var result = controller.GetLeftCapacity(fromTime, toTime);

            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
