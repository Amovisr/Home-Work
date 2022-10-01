using MetricsAgent.Controllers;
using MetricsAgent.Models.Requests;
using MetricsAgent.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MetricsAgentTests.Controllers
{
    public class ErrorsDotNetMetricsControllerTests
    {

        private readonly ErrorMetricsController _controller;
        private readonly Mock<IErrorMetricsRepository> _repositoryMock;
        private readonly Mock<ILogger<ErrorMetricsController>> _loggerMock;

        public ErrorsDotNetMetricsControllerTests()
        {
            _repositoryMock = new Mock<IErrorMetricsRepository>();
            _loggerMock = new Mock<ILogger<ErrorMetricsController>>();

            _controller = new ErrorsDotNetMetricsController(_repositoryMock.Object, _loggerMock.Object);
        }


        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            // устанавливаем параметр заглушки
            // в заглушке прописываем что в репозиторий прилетит CpuMetric объект
            _repositoryMock.Setup(repository =>
                repository.Create(It.IsAny<ErrorMetric>())).Verifiable();

            // выполняем действие на контроллере
            var result = _controller.Create(new ErrorMetricCreateRequest
            {
                Time = DateTimeOffset.Now,
                Count = 50
            });

            _repositoryMock.Verify(repository =>
                repository.Create(It.IsAny<ErrorMetric>()), Times.AtMostOnce());
        }

        [Fact]
        public void GetByTimePeriod_ShouldCall_GetByTimePeriod_From_Repository()
        {
            _repositoryMock.Setup(repository =>
                repository.GetByTimePeriod(It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>()))
                .Returns(new List<ErrorMetric>());

            _controller.GetErrorMetrics(DateTimeOffset.Now, DateTimeOffset.Now);

            _repositoryMock.Verify(repository =>
                repository.GetByTimePeriod(It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>()), Times.AtMostOnce());

        }
    }
}
