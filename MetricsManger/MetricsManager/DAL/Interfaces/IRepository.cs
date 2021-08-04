using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MetricsManager.DAL.Models;

namespace MetricsManager.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IList<T> GetMetricsFromAgent(int agentId, DateTimeOffset fromTime, DateTimeOffset toTime);

        IList<T> GetMetricsFromAllCluster(DateTimeOffset fromTime, DateTimeOffset toTime);

        void Create(T item);

        long GetLastTime(int id);
    }
}
