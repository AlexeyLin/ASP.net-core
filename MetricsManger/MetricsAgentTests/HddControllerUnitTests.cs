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
        public void GetErrorsCount_ReturnsOk()
        {
            //Arrange

            //Act
            var result = controller.GetLeftCapacity();

            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
