﻿namespace MetricsAgent.Models.Requests
{
    public class NetworkMetricCreateRequest
    {
        public int Value { get; set; }

        public DateTimeOffset Time { get; set; }

    }
}
