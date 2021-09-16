using MetricAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace MetricAgentTests
{
    public class RamMetricsControllerUnitTests
    {
        private RamController controller;

        public RamMetricsControllerUnitTests()
        {
            controller = new RamController();
        }

        [Fact]
        public void RamControllerHi_ReturnsOk()
        {
            //Arrange
            //Act
            var result = controller.Hi();

            // Assert
            Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}

