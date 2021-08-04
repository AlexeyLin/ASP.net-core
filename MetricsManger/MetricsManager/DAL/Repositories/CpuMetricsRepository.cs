using MetricsManager.DAL.Interfaces;
using MetricsManager.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using Dapper;

namespace MetricsManager.DAL.Repositories
{
    public class CpuMetricsRepository : ICpuMetricsRepository
    {
        private const string ConnectionString = "Data Source=metrics.db;Version=3;Pooling=true;Max Pool Size=100;";

        public IList<CpuMetric> GetMetricsFromAgent(int agentId, DateTimeOffset fromTime, DateTimeOffset toTime)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                return connection.Query<CpuMetric>("SELECT * FROM cpumetrics WHERE time>@from AND time<@to AND agentid=@id",
                    new
                    {
                        from = fromTime.ToUnixTimeSeconds(),
                        to = toTime.ToUnixTimeSeconds(),
                        id = agentId
                    }).ToList();
            }
        }

        public IList<CpuMetric> GetMetricsFromAllCluster(DateTimeOffset fromTime, DateTimeOffset toTime)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                return connection.Query<CpuMetric>("SELECT * FROM cpumetrics WHERE time>@from AND time<@to",
                    new
                    {
                        from = fromTime.ToUnixTimeSeconds(),
                        to = toTime.ToUnixTimeSeconds(),
                    }).ToList();
            }
        }
    }
}

