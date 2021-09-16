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
    public class CpuMetricsControllerUnitTests
    {
        private CpuController controller;
        private Mock<ILogger<CpuController>> mock_logger;
        private Mock<ICpuMetricsRepository> mock_repository;


        public CpuMetricsControllerUnitTests()
        {
            mock_logger = new Mock<ILogger<CpuController>>();
            mock_repository = new Mock<ICpuMetricsRepository>();

            controller = new CpuController(mock_logger.Object, mock_repository.Object);
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
