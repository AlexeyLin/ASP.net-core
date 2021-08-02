using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MetricsAgent.DAL.Models;

namespace MetricsManager.DAL.Repositories
{
    public class AgentsRepository
    {
        private const string ConnectionString = "Data Source=metrics.db;Version=3;Pooling=true;Max Pool Size=100;";

        public void Create(CpuMetric item)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Open();
            using var cmd = new SQLiteCommand(connection);

            cmd.CommandText = "INSERT INTO cpumetrics(value, time) VALUES(@value, @time)";
            cmd.Parameters.AddWithValue("@value", item.Value);
            cmd.Parameters.AddWithValue("@time", item.Time);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }

        public IList<CpuMetric> GetByTimePeriod(DateTimeOffset fromTime, DateTimeOffset toTime)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                return connection.Query<CpuMetric>("SELECT * FROM cpumetrics WHERE time>@from AND time<@to",
                    new
                    {
                        from = fromTime.ToUnixTimeSeconds(),
                        to = toTime.ToUnixTimeSeconds()
                    }).ToList();
            }
        }

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
            
        }

        
        public void DisableAgentById(int agentId)
        {
            
        }
    }
}
