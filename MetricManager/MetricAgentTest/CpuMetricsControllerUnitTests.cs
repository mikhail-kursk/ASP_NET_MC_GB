using MetricAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace MetricAgentTests
{
    public class CpuMetricsControllerUnitTests
    {
        private CpuController controller;

        public CpuMetricsControllerUnitTests()
        {
            controller = new CpuController();
        }

        [Fact]
        public void CpuControllerHi_ReturnsOk()
        {
            //Arrange
            //Act
            var result = controller.Hi();

            // Assert
            Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
