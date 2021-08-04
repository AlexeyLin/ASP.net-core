using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using Dapper;
using MetricsAgent.DAL.Interfaces;

namespace MetricsManager.DAL.Repositories
{
    public class AgentsRepository: IAgentsRepository<AgentInfo>
    {
        private const string ConnectionString = "Data Source=metrics.db;Version=3;Pooling=true;Max Pool Size=100;";

        public IList<AgentInfo> GetListRegisterAgents()
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                return connection.Query<AgentInfo>("SELECT id, address FROM agents")
                    .ToList();
            }
        }

        public void RegisterAgent(AgentInfo item)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            { 
                connection.Execute("INSERT INTO agents(id, address) VALUES(@id, @address)",
                    new
                    {
                        id = item.Id,
                        address = item.Address.ToString()
                    });
            }

        }

        
        public void EnableAgentById(int agentId)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Execute("UPDATE agents SET status = 'Enable' WHERE id = @id",
                    new
                    {
                        id = agentId
                    });
            }
        }

        
        public void DisableAgentById(int agentId)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Execute("UPDATE agents SET status = 'Disable' WHERE id = @id",
                    new
                    {
                        id = agentId
                    });
            }
        }
    }
}
