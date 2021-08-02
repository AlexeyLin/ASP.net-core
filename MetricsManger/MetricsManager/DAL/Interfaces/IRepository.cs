using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IList<T> GetMetricsFromAgent(int agentId, DateTimeOffset fromTime, DateTimeOffset toTime);

        IList<T> GetMetricsFromAllCluster(DateTimeOffset fromTime, DateTimeOffset toTime);
    }
}
