﻿using MetricsAgent.DAL.Interfaces;
using MetricsAgent.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace MetricsAgent.DAL.Repositories
{
    public class NetworkMetricsRepository: INetworkMetricsRepository
    {
        private const string ConnectionString = "Data Source=metrics.db;Version=3;Pooling=true;Max Pool Size=100;";

        public void Create(NetworkMetric item)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Open();
            using var cmd = new SQLiteCommand(connection);

            cmd.CommandText = "INSERT INTO networkmetrics(value, time) VALUES(@value, @time)";
            cmd.Parameters.AddWithValue("@value", item.Value);
            cmd.Parameters.AddWithValue("@time", item.Time);

            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }

        public IList<NetworkMetric> GetByTimePeriod(DateTimeOffset fromTime, DateTimeOffset toTime)
        {
            var returnList = new List<NetworkMetric>();

            using var connection = new SQLiteConnection(ConnectionString);
            connection.Open();
            using var cmd = new SQLiteCommand(connection);

            cmd.CommandText = "SELECT * FROM networkmetrics WHERE time>@fromTime AND time<@toTime";
            cmd.Parameters.AddWithValue("@fromTime", fromTime.ToUnixTimeSeconds());
            cmd.Parameters.AddWithValue("@toTime", toTime.ToUnixTimeSeconds());
            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    returnList.Add(new NetworkMetric
                    {
                        Id = reader.GetInt32(0),
                        Value = reader.GetInt32(1),
                        Time = reader.GetInt64(2)
                    });
                }
            }
            return returnList;
        }
    }
}