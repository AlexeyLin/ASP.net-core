using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Text.Json;
using MetricsManager.Requests;
using MetricsManager.Responses;

namespace MetricsManager.Client
{
    public class MetricsAgentClient: IMetricsAgentClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger _logger;

        public MetricsAgentClient(HttpClient httpClient, ILogger logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public AllRamMetricsApiResponse GetRamMetrics(RamMetricApiRequest request)
        {
            var fromParameter = request.FromTime.ToUnixTimeSeconds();
            var toParameter = request.ToTime.ToUnixTimeSeconds();
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"{request.ClientBaseAddress}/api/metrics/ram/available/from/{fromParameter}/to/{toParameter}");
            try
            {
                HttpResponseMessage response = _httpClient.SendAsync(httpRequest).Result;

                using var responseStream = response.Content.ReadAsStreamAsync().Result;
                return JsonSerializer.DeserializeAsync<AllRamMetricsApiResponse>(responseStream).Result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public AllHddMetricsApiResponse GetHddMetrics(HddMetricApiRequest request)
        {
            var fromParameter = request.FromTime.ToUnixTimeSeconds();
            var toParameter = request.ToTime.ToUnixTimeSeconds();
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"{request.ClientBaseAddress}/api/metrics/hdd/left/from/{fromParameter}/to/{toParameter}");
            try
            {
                HttpResponseMessage response = _httpClient.SendAsync(httpRequest).Result;

                using var responseStream = response.Content.ReadAsStreamAsync().Result;
                return JsonSerializer.DeserializeAsync<AllHddMetricsApiResponse>(responseStream).Result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }


        public AllDotNetMetricsApiResponse GetDotNetMetrics(DotNetMetricApiRequest request)
        {
            var fromParameter = request.FromTime.ToUnixTimeSeconds();
            var toParameter = request.ToTime.ToUnixTimeSeconds();
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"{request.ClientBaseAddress}/api/metrics/dotnet/errors-count/from/{fromParameter}/to/{toParameter}");
            try
            {
                HttpResponseMessage response = _httpClient.SendAsync(httpRequest).Result;

                using var responseStream = response.Content.ReadAsStreamAsync().Result;
                return JsonSerializer.DeserializeAsync<AllDotNetMetricsApiResponse>(responseStream).Result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public AllCpuMetricsApiResponse GetCpuMetrics(CpuMetricApiRequest request)
        {
            var fromParameter = request.FromTime.ToUnixTimeSeconds();
            var toParameter = request.ToTime.ToUnixTimeSeconds();
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"{request.ClientBaseAddress}/api/metrics/cpu/from/{fromParameter}/to/{toParameter}");
            try
            {
                HttpResponseMessage response = _httpClient.SendAsync(httpRequest).Result;

                using var responseStream = response.Content.ReadAsStreamAsync().Result;
                return JsonSerializer.DeserializeAsync<AllCpuMetricsApiResponse>(responseStream).Result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public AllNetworkMetricsApiResponse GetNetworkMetrics(NetworkMetricApiRequest request)
        {
            var fromParameter = request.FromTime.ToUnixTimeSeconds();
            var toParameter = request.ToTime.ToUnixTimeSeconds();
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"{request.ClientBaseAddress}/api/metrics/network/from/{fromParameter}/to/{toParameter}");
            try
            {
                HttpResponseMessage response = _httpClient.SendAsync(httpRequest).Result;

                using var responseStream = response.Content.ReadAsStreamAsync().Result;
                return JsonSerializer.DeserializeAsync<AllNetworkMetricsApiResponse>(responseStream).Result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }
    }
}
