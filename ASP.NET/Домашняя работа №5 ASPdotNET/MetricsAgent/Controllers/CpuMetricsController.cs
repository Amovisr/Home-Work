using MetricsAgent.Models.Requests;
using MetricsAgent.Models;
using MetricsAgent.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using MetricsAgent.Models.Dto;

namespace MetricsAgent.Controllers
{
    [Route("api/metrics/cpu")]
    [ApiController]
    public class CpuMetricsController : ControllerBase
    {
        #region Services

        private readonly ILogger<CpuMetricsController> _logger;
        private readonly ICpuMetricsRepository _cpuMetricsRepository;
        private readonly IMapper _mapper;

        #endregion


        public CpuMetricsController(
            ICpuMetricsRepository cpuMetricsRepository,
            ILogger<CpuMetricsController> logger,
            IMapper mapper)
        {
            _cpuMetricsRepository = cpuMetricsRepository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] CpuMetricCreateRequest request)
        {

            // Вариант 2 (AutoMapper)
            _cpuMetricsRepository.Create(_mapper.Map<CpuMetric>(request));
            return Ok();
        }

        /// <summary>
        /// Получить статистику по нагрузке на ЦП за период
        /// </summary>
        /// <param name="fromTime">Время начала периода</param>
        /// <param name="toTime">Время окончания периода</param>
        /// <returns></returns>
        [HttpGet("from/{fromTime}/to/{toTime}")]
        public ActionResult<IList<CpuMetricDto>> GetCpuMetrics(
            [FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            _logger.LogInformation("Get cpu metrics call.");
            return Ok(_cpuMetricsRepository.GetByTimePeriod(fromTime, toTime)
                .Select(metric => _mapper.Map<CpuMetricDto>(metric)).ToList());
        }

        [HttpGet("all")]
        public ActionResult<IList<CpuMetricDto>> GetAllCpuMetrics()
        {
            return Ok(_cpuMetricsRepository.GetAll()
                .Select(metric => _mapper.Map<CpuMetricDto>(metric)).ToList());
        }

    }
}