namespace MetricsAgent.Models.Requests
{
    public class HddMetricCreateRequest
    {
        public int Value { get; set; }

        public DateTimeOffset Time { get; set; }

    }
}
