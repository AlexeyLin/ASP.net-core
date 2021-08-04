using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MetricsManager.Requests;
using MetricsManager.Responses;

namespace MetricsManager.Client
{
    interface IMetricsAgentClient
    {
        AllRamMetricsApiResponse GetRamMetrics(RamMetricApiRequest request);

        AllHddMetricsApiResponse GetHddMetrics(HddMetricApiRequest request);

        AllDotNetMetricsApiResponse GetDotNetMetrics(DotNetMetricApiRequest request);

        AllCpuMetricsApiResponse GetCpuMetrics(CpuMetricApiRequest request);

        AllNetworkMetricsApiResponse GetNetworkMetrics(NetworkMetricApiRequest request);
    }
}
