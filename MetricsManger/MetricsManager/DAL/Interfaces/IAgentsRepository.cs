using System.Collections.Generic;
using MetricsManager;

namespace MetricsAgent.DAL.Interfaces
{
    public interface IAgentsRepository<T> where T : class
    {
        IList<T> GetListRegisterAgents();

        void RegisterAgent(T item);

        void EnableAgentById(int agentId);

        void DisableAgentById(int agentId);
    }
}
