﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Responses
{
    public class AllRamMetricsApiResponse
    {
        public List<RamMetricDtoApi> Metrics { get; set; }
    }
}
