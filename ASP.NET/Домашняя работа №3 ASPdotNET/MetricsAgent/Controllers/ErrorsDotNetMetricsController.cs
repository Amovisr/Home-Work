using MetricsAgent.Models.Requests;
using MetricsAgent.Models;
using MetricsAgent.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MetricsAgent.Services.Impl;

namespace MetricsAgent.Controllers
{
    [Route("api/metrics/dotnet/errors-count")]
    [ApiController]
    public class ErrorsDotNetMetricsController : ControllerBase
    {
        #region Services

        private readonly ILogger<ErrorsDotNetMetricsController> _logger;
        private readonly IErrorMetricsRepository _errorMetricsRepository;

        #endregion


        public ErrorsDotNetMetricsController(
            IErrorMetricsRepository errorMetricsRepository,
            ILogger<ErrorsDotNetMetricsController> logger)
        {
            _errorMetricsRepository = errorMetricsRepository;
            _logger = logger;
        }

        [HttpPost("create-error")]
        public IActionResult Create([FromBody] ErrorMetricCreateRequest request)
        {
            _errorMetricsRepository.Create(new Models.ErrorMetric
            {
                Count = request.Count,
                Time = (int)request.Time.Second
            });
            return Ok();
        }
        /// <summary>
        /// Получить статистику по количеству ошибок за период
        /// </summary>
        /// <param name="fromTime">Время начала периода</param>
        /// <param name="toTime">Время окончания периода</param>
        /// <returns></returns>
        [HttpGet("from/{fromTime}/to/{toTime}")]
        public IActionResult GetErrorMetrics(
            [FromRoute] DateTimeOffset fromTime, [FromRoute] DateTimeOffset toTime)
        {
            _logger.LogInformation("Get error metrics call.");
            return Ok(_errorMetricsRepository.GetByTimePeriod(fromTime, toTime));
        }



    }
}
