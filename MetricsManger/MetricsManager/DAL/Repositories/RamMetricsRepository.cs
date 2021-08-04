﻿using MetricsManager.DAL.Interfaces;
using MetricsManager.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using Dapper;

namespace MetricsManager.DAL.Repositories
{
    public class RamMetricsRepository: IRamMetricsRepository
    {
        private const string ConnectionString = "Data Source=metrics.db;Version=3;Pooling=true;Max Pool Size=100;";

        public IList<RamMetric> GetMetricsFromAgent(int agentId, DateTimeOffset fromTime, DateTimeOffset toTime)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                return connection.Query<RamMetric>("SELECT * FROM rammetrics WHERE time>@from AND time<@to AND agentid=@id",
                    new
                    {
                        from = fromTime.ToUnixTimeSeconds(),
                        to = toTime.ToUnixTimeSeconds(),
                        id = agentId
                    }).ToList();
            }
        }

        public IList<RamMetric> GetMetricsFromAllCluster(DateTimeOffset fromTime, DateTimeOffset toTime)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                return connection.Query<RamMetric>("SELECT * FROM rammetrics WHERE time>@from AND time<@to",
                    new
                    {
                        from = fromTime.ToUnixTimeSeconds(),
                        to = toTime.ToUnixTimeSeconds(),
                    }).ToList();
            }
        }

        public long GetLastTime(int id)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                return connection.QuerySingle("SELECT MAX(time) FROM rammetrics WHERE agentid = @id",
                    new
                    {
                        id = id
                    });
            }
        }

        public void Create(RamMetric item)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Execute("INSERT INTO rammetrics(value, time, agentid) VALUES(@value, @time, @agentid)",
                    new
                    {
                        value = item.Value,
                        time = item.Time,
                        agentid = item.AgentId
                    });
            }
        }
    }
}
