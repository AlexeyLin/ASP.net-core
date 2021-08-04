﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace MetricsManager.Requests
{
    public class HddMetricApiRequest
    {
        public DateTimeOffset FromTime { get; set; }

        public DateTimeOffset ToTime { get; set; }

        public Url ClientBaseAddress { get; set; }
    }
}
