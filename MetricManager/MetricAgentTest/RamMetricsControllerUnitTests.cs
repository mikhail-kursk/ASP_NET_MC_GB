using MetricAgent.Controllers;
using MetricAgent.Logic;
using MetricAgent.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace MetricAgentTests
{
    public class RamMetricsControllerUnitTests
    {
        private RamController controller;
        private Mock<ILogger<RamController>> mock_logger;
        private Mock<IRamMetricsRepository> mock_repository;

        public RamMetricsControllerUnitTests()
        {
            mock_logger = new Mock<ILogger<RamController>>();
            mock_repository = new Mock<IRamMetricsRepository>();

            controller = new RamController(mock_logger.Object, mock_repository.Object);
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

        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            //Arrange
            mock_repository.Setup(repository => repository.Create(It.IsAny<Metric>())).Verifiable();

            //Act
            var result = controller.Create(new MetricAgent.Models.MetricCreateRequest { Time = DateTime.Parse("2020-01-10"), Value = 50 });

            // Assert
            mock_repository.Verify(repository => repository.Create(It.IsAny<Metric>()), Times.AtMostOnce());

        }
    }
}

