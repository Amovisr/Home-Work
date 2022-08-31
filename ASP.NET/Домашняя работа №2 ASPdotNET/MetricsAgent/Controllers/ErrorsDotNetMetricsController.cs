using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MetricsAgent.Controllers
{
    [Route("api/metrics/dotnet/errors-count")]
    [ApiController]
    public class ErrorsDotNetMetricsController : ControllerBase
    {
        /// <summary>
        /// Получить статистику по количеству ошибок за период
        /// </summary>
        /// <param name="fromTime">Время начала периода</param>
        /// <param name="toTime">Время окончания периода</param>
        /// <returns></returns>
        [HttpGet("from/{fromTime}/to/{toTime}")]
        public IActionResult GetErrorMetrics(
            [FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            return Ok();
        }


        // TODO: Домашнее задание [Пункт 2]
        // В проект агента сбора метрик добавьте контроллеры для сбора метрик, аналогичные
        // менеджеру сбора метрик.Добавьте методы для получения метрик с агента, доступные по
        //следующим путям
        // a. api/metrics/cpu/from/{fromTime}/to/{toTime} [ВЫПОЛНИЛИ ВМЕСТЕ]
        // b. api / metrics / dotnet / errors - count / from /{ fromTime}/ to /{ toTime}
        // c. api / metrics / network / from /{ fromTime}/ to /{ toTime} [ВЫПОЛНИЛ]
        // d. api / metrics / hdd / left / from /{ fromTime}/ to /{ toTime} [ВЫПОЛНИЛ]
        // e. api / metrics / ram / available / from /{ fromTime}/ to /{ toTime} [ВЫПОЛНИЛ]

    }
}
