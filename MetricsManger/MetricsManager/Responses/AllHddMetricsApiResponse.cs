﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Responses
{
    public class AllHddMetricsApiResponse
    {
        public List<HddMetricDtoApi> Metrics { get; set; }
    }
}