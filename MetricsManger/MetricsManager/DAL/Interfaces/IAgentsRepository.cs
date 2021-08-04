using System.Collections.Generic;
using MetricsManager.DAL.Models;

namespace MetricsManager.DAL.Interfaces
{
    public interface IAgentsRepository
    {
        IList<AgentInfo> GetListRegisterAgents();

        void RegisterAgent(AgentInfo item);

        void EnableAgentById(int agentId);

        void DisableAgentById(int agentId);
    }
}
