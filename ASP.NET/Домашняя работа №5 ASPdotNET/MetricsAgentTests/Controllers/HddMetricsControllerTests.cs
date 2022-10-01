using MetricsAgent.Controllers;
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
    public class HddMetricsControllerTests
    {
        private readonly HddMetricsController _controller;
        private readonly Mock<IHddMetricsRepository> _repositoryMock;
        private readonly Mock<ILogger<HddMetricsController>> _loggerMock;

        public HddMetricsControllerTests()
        {
            _repositoryMock = new Mock<IHddMetricsRepository>();
            _loggerMock = new Mock<ILogger<HddMetricsController>>();

            _controller = new HddMetricsController(_repositoryMock.Object, _loggerMock.Object);
        }


        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            // устанавливаем параметр заглушки
            // в заглушке прописываем что в репозиторий прилетит CpuMetric объект
            _repositoryMock.Setup(repository =>
                repository.Create(It.IsAny<HddMetric>())).Verifiable();

            // выполняем действие на контроллере
            var result = _controller.Create(new HddMetricCreateRequest
            {
                Time = DateTimeOffset.Now,
                Value = 50
            });

            _repositoryMock.Verify(repository =>
                repository.Create(It.IsAny<HddMetric>()), Times.AtMostOnce());
        }

        [Fact]
        public void GetByTimePeriod_ShouldCall_GetByTimePeriod_From_Repository()
        {
            _repositoryMock.Setup(repository =>
                repository.GetByTimePeriod(It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>()))
                .Returns(new List<HddMetric>());

            _controller.GetHddMetrics(DateTimeOffset.Now, DateTimeOffset.Now);

            _repositoryMock.Verify(repository =>
                repository.GetByTimePeriod(It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>()), Times.AtMostOnce());
        }
    }
}