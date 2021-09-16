using MetricAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace MetricAgentTests
{
    public class HddMetricsControllerUnitTests
    {
        private HddController controller;

        public HddMetricsControllerUnitTests()
        {
            controller = new HddController();
        }

        [Fact]
        public void HddControllerHi_ReturnsOk()
        {
            //Arrange
            //Act
            var result = controller.Hi();

            // Assert
            Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}

