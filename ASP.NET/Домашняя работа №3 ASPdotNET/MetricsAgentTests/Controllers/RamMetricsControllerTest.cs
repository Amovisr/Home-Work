using MetricsAgent.Controllers;
using MetricsAgent.Services.Impl;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetricsAgentTests.Controllers
{
    public class RamMetricsControllerTest
    {
        private readonly RamMetricsController _controller;
        private readonly Mock<IRamMetricsRepository> _repositoryMock;
        private readonly Mock<ILogger<RamMetricsController>> _loggerMock;

        public RamMetricsControllerTest()
        {
            _repositoryMock = new Mock<IRamMetricsRepository>();
            _loggerMock = new Mock<ILogger<RamMetricsController>>();

            _controller = new RamMetricsController(_repositoryMock.Object, _loggerMock.Object);
        }


        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            // устанавливаем параметр заглушки
            // в заглушке прописываем что в репозиторий прилетит CpuMetric объект
            _repositoryMock.Setup(repository =>
                repository.Create(It.IsAny<RamMetric>())).Verifiable();

            // выполняем действие на контроллере
            var result = _controller.Create(new RamMetricCreateRequest
            {
                Time = DateTimeOffset.Now,
                Value = 50
            });

            _repositoryMock.Verify(repository =>
                repository.Create(It.IsAny<RamMetric>()), Times.AtMostOnce());
        }

        [Fact]
        public void GetByTimePeriod_ShouldCall_GetByTimePeriod_From_Repository()
        {
            _repositoryMock.Setup(repository =>
                repository.GetByTimePeriod(It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>()))
                .Returns(new List<RamMetric>());

            _controller.GetRamMetrics(DateTimeOffset.Now, DateTimeOffset.Now);

            _repositoryMock.Verify(repository =>
                repository.GetByTimePeriod(It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>()), Times.AtMostOnce());
        }
    }
}
