using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Responses
{
    public class AllAgentInfoResponse
    {
        public List<AgentInfoDto> Metrics { get; set; }
    }
}
