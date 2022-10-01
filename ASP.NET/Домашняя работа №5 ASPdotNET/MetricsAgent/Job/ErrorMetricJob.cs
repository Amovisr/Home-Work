using MetricsAgent.Services;
using Quartz;
using System.Diagnostics;

namespace MetricsAgent.Job
{
    public class ErrorMetricJob : IJob
    {
        private PerformanceCounter _errorCounter;
        private IServiceScopeFactory _serviceScopeFactory;

        public ErrorMetricJob(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;

            _errorCounter = new PerformanceCounter(".NET CLR Memory", "# Bytes in all heaps", "_Global_");
            _errorCounter = new PerformanceCounter(".NET CLR Exceptions", "# of Exceps Thrown / sec", "_Global_");
             
        }


        public Task Execute(IJobExecutionContext context)
        {

            using (IServiceScope serviceScope = _serviceScopeFactory.CreateScope())
            {
                var errorMetricsRepository = serviceScope.ServiceProvider.GetService<IErrorMetricsRepository>();
                try
                {
                    var errorUsageInPercents = _errorCounter.NextValue();
                    var time = TimeSpan.FromSeconds(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
                    Debug.WriteLine($"{time} > {errorUsageInPercents}");
                    errorMetricsRepository.Create(new Models.ErrorMetric
                    {
                        Value = (int)errorUsageInPercents,
                        Time = (long)time.TotalSeconds
                    });
                }
                catch (Exception ex)
                {

                }
            }


            return Task.CompletedTask;
        }
    }
}
