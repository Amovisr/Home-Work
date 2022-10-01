namespace MetricsAgent.Models.Requests
{
    public class ErrorMetricCreateRequest
    {
        public int Value { get; set; }

        public TimeSpan Time { get; set; }
    }
}
