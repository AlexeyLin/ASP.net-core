using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Responses
{
    public class AllNetworkMetricsApiResponse
    {
        public List<NetworkMetricDtoApi> Metrics { get; set; }
    }
}
