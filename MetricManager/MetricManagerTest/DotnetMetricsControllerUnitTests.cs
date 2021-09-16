using MetricManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace MetricsManagerTests
{
    public class DotnetMetricsControllerUnitTests
    {
        private DotnetController controller;

        public DotnetMetricsControllerUnitTests()
        {
            controller = new DotnetController();
        }

        [Fact]
        public void DotnetControllerHi_ReturnsOk()
        {
            //Arrange
            //Act
            var result = controller.Hi();

            // Assert
            Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}

