namespace MetricsAgent.Models.Requests
{
    public class ErrorMetricCreateRequest
    {
        public int Count { get; set; }

        public DateTimeOffset Time { get; set; }
    }
}
