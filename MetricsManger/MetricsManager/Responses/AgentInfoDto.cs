using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace MetricsManager.Responses
{
    public class AgentInfoDto
    {
        public int Id { get; set; }

        public Url Address { get; set; }
    }
}
