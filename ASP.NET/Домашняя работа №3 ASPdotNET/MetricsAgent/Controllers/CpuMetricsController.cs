using MetricsAgent.Models.Requests;
using MetricsAgent.Models;
using MetricsAgent.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MetricsAgent.Controllers
{
    [Route("api/metrics/cpu")]
    [ApiController]
    public class CpuMetricsController : ControllerBase
    {
        /// <summary>
        /// Получить статистику по нагрузке на ЦП за период
        /// </summary>
        /// <param name="fromTime">Время начала периода</param>
        /// <param name="toTime">Время окончания периода</param>
        /// <returns></returns>
       #region Services

        private readonly ILogger<CpuMetricsController> _logger;
        private readonly ICpuMetricsRepository _cpuMetricsRepository;



        #endregion


        public CpuMetricsController(
            ICpuMetricsRepository CpuMetricsRepository,
            ILogger<CpuMetricsController> logger)
        {
            _cpuMetricsRepository = CpuMetricsRepository;
            _logger = logger;
        }

        [HttpPost("create-cpu")]
        public ActionResult Create([FromBody] CpuMetricCreateRequest request)
        {
            _cpuMetricsRepository.Create(new Models.CpuMetric
            {
                Value = request.Value,
                Time = (int)request.Time.Second
            }) ;
            return Ok();
        }

        /// <summary>
        /// Получить статистику по нагрузке на ЦП за период
        /// </summary>
        /// <param name="fromTime">Время начала периода</param>
        /// <param name="toTime">Время окончания периода</param>
        /// <returns></returns>
        [HttpGet("from/{fromTime}/to/{toTime}")]
        public ActionResult<IList<CpuMetric>> GetCpuMetrics(
            [FromRoute] DateTimeOffset fromTime, [FromRoute] DateTimeOffset toTime)
        {

            _logger.LogInformation("Get cpu metrics call.");
            return Ok(_cpuMetricsRepository.GetByTimePeriod(fromTime, toTime));
        }

        //[HttpGet("from/{fromTime}/to/{toTime}")]
        //public IActionResult GetCpuPercentilesMetrics(
        //    [FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        //{
        //    int percentiles = 0;

        //    return Ok(percentiles);
        //}


    }
}
