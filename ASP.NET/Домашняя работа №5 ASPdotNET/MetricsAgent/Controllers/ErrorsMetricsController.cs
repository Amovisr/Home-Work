using MetricsAgent.Models.Requests;
using MetricsAgent.Models;
using MetricsAgent.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MetricsAgent.Services.Impl;
using AutoMapper;
using MetricsAgent.Models.Dto;

namespace MetricsAgent.Controllers
{
    [Route("api/metrics/dotnet/errors-count")]
    [ApiController]
    public class ErrorMetricsController : ControllerBase
    {
        #region Services

        private readonly ILogger<ErrorMetricsController> _logger;
        private readonly IErrorMetricsRepository _errorMetricsRepository;
        private readonly IMapper _mapper;

        #endregion


        public ErrorMetricsController(
            IErrorMetricsRepository errorMetricsRepository,
            ILogger<ErrorMetricsController> logger,
            IMapper mapper)
        {
            _errorMetricsRepository = errorMetricsRepository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] ErrorMetricCreateRequest request)
        {
            _errorMetricsRepository.Create(_mapper.Map<ErrorMetric>(request));
            return Ok();
        }

        /// <summary>
        /// Получить статистику по нагрузке на ЦП за период
        /// </summary>
        /// <param name="fromTime">Время начала периода</param>
        /// <param name="toTime">Время окончания периода</param>
        /// <returns></returns>
        [HttpGet("from/{fromTime}/to/{toTime}")]
        public ActionResult<IList<ErrorMetricDto>> GetCpuMetrics(
            [FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            _logger.LogInformation("Get error metrics call.");

            return Ok(_errorMetricsRepository.GetByTimePeriod(fromTime, toTime)
                .Select(metric => _mapper.Map<ErrorMetricDto>(metric)).ToList());
        }
        [HttpGet("all")]
        public ActionResult<IList<ErrorMetricDto>> GetAllCpuMetrics()
        {
            return Ok(_errorMetricsRepository.GetAll()
                .Select(metric => _mapper.Map<ErrorMetricDto>(metric)).ToList());
        }
    }
}
