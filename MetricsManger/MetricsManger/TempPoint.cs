using System;

namespace MetricsManger
{
    public class TempPoint
    {
        public DateTime DataTemp { get; set; }

        public int Temp { get; set; }

        public TempPoint(DateTime inputData, int inputTemp)
        {
            DataTemp = inputData;
            Temp = inputTemp;
        }
    }
}