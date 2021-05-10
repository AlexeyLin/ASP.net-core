using System;
using System.Collections.Generic;

namespace MetricsManger
{
    public class ValuesHolder
    {
        public List<TempPoint> Values { get; set; }

        public ValuesHolder()
        {
            Values = new List<TempPoint>();
        }
    }
}