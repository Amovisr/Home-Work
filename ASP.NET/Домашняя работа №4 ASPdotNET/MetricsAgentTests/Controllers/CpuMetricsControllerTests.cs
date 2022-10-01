using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MetricsAgent.Models.Requests;
using MetricsAgent.Services;
using MetricsAgent.Models;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using AutoMapper;

namespace MetricsAgentTests.Controllers
{

    public class CpuMetricsControllerTests
    {
      
        private readonly CpuMetricsController _controller;
        private readonly Mock<ICpuMetricsRepository> _repositoryMock;
        private readonly Mock<ILogger<CpuMetricsController>> _loggerMock;
        private readonly Mock<IMapper> _mapper;

        public CpuMetricsControllerTests()
        {
            _repositoryMock = new Mock<ICpuMetricsRepository>();
            _loggerMock = new Mock<ILogger<CpuMetricsController>>();

            _controller = new CpuMetricsController(_repositoryMock.Object, _loggerMock.Object , _mapper.Object);
        }


        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            // устанавливаем параметр заглушки
            // в заглушке прописываем что в репозиторий прилетит CpuMetric объект
            _repositoryMock.Setup(repository =>
                repository.Create(It.IsAny<CpuMetric>())).Verifiable();

            // выполняем действие на контроллере
            var result = _controller.Create(new CpuMetricCreateRequest
            {
                Time = TimeSpan.FromSeconds(50),
                Value = 50
            });

            _repositoryMock.Verify(repository =>
                repository.Create(It.IsAny<CpuMetric>()), Times.AtMostOnce());
        }

        [Fact]
        public void GetByTimePeriod_ShouldCall_GetByTimePeriod_From_Repository()
        {
            _repositoryMock.Setup(repository =>
                repository.GetByTimePeriod(It.IsAny<TimeSpan>(), It.IsAny<TimeSpan>()))
                .Returns(new List<CpuMetric>());

            _controller.GetCpuMetrics(TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(50));

            _repositoryMock.Verify(repository =>
                repository.GetByTimePeriod(It.IsAny<TimeSpan>(), It.IsAny<TimeSpan>()), Times.AtMostOnce());

        }
    }

}

