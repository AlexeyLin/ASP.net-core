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
        public void GetErrorsCount_ReturnsOk()
        {
            //Arrange

            //Act
            var result = controller.GetAvailableRam();

            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
