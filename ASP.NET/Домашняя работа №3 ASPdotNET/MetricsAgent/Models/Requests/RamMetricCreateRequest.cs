namespace MetricsAgent.Models.Requests
{
    public class RamMetricCreateRequest
    {
        public int Value { get; set; }

        public DateTimeOffset Time { get; set; }

    }
}
