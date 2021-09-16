using MetricAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace MetricAgentTests
{
    public class NetworkMetricsControllerUnitTests
    {
        private NetworkController controller;

        public NetworkMetricsControllerUnitTests()
        {
            controller = new NetworkController();
        }

        [Fact]
        public void NetworkControllerHi_ReturnsOk()
        {
            //Arrange
            //Act
            var result = controller.Hi();

            // Assert
            Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}

