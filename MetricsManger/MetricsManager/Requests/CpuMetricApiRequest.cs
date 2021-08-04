using System;
using System.Security.Policy;

namespace MetricsManager.Requests
{
    public class CpuMetricApiRequest
    {
        public DateTimeOffset FromTime { get; set; }

        public DateTimeOffset ToTime { get; set; }

        public Url ClientBaseAddress { get; set; }
    }
}
