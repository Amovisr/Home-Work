using MetricsAgent.Models.Requests;
using MetricsAgent.Services;
using MetricsAgent.Services.Impl;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MetricsAgent.Controllers
{
    [Route("api/metrics/ram/available")]
    [ApiController]
    public class RamMetricsController : ControllerBase
    {
        #region Services

        private readonly ILogger<RamMetricsController> _logger;
        private readonly IRamMetricsRepository _ramMetricsRepository;

        #endregion


        public RamMetricsController(
            IRamMetricsRepository RamMetricsRepository,
            ILogger<RamMetricsController> logger)
        {
            _ramMetricsRepository = RamMetricsRepository;
            _logger = logger;
        }

        [HttpPost("create-ram")]
        public IActionResult Create([FromBody] RamMetricCreateRequest request)
        {
            _ramMetricsRepository.Create(new Models.RamMetric
            {
                Value = request.Value,
                Time = (int)request.Time.Second
            });
            return Ok();
        }
        /// <summary>
        /// Получить статистику по остаточной памяти на RAM(Оперативая память) за период
        /// </summary>
        /// <param name="fromTime">Время начала периода</param>
        /// <param name="toTime">Время окончания периода</param>
        /// <returns></returns>
        [HttpGet("from/{fromTime}/to/{toTime}")]
        public IActionResult GetRamMetrics(
            [FromRoute] DateTimeOffset fromTime, [FromRoute] DateTimeOffset toTime)
        {
            _logger.LogInformation("Get cpu metrics call.");
            return Ok(_ramMetricsRepository.GetByTimePeriod(fromTime, toTime));
        }
    }
}
