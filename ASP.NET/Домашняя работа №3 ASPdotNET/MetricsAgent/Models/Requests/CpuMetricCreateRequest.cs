namespace MetricsAgent.Models.Requests
{
    public class CpuMetricCreateRequest
    {
        public int Value { get; set; }

        public DateTimeOffset Time { get; set; }
    }
}
