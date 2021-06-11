using System;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;

namespace OrderFactory.Nacha.Parser.Data
{
    public interface ISqlConnectionFactory
    {
        IDbConnection CreateConnection();
        Task<(bool, string)> ConnectionStatus();
    }

    public class SqlConnectionFactory : ISqlConnectionFactory
    {
        private readonly string _connectionString;

        public SqlConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection CreateConnection()
        {
            var connection = new SqlConnection(_connectionString);
            return connection;
        }

        public async Task<(bool, string)> ConnectionStatus()
        {
            string statusString;
            bool isHealthy;
            try
            {
                var connection = CreateConnection();
                isHealthy = await connection.ExecuteScalarAsync<bool>("SELECT 1");
                var result = isHealthy ? "healthy" : "unhealthy";
                var userName = await connection.ExecuteScalarAsync<string>("SELECT SYSTEM_USER");
                statusString = $"Connection {result}. Context: '{userName}'.";
            }
            catch (Exception e)
            {
                statusString = $"Connection unhealthy: {e.Message}";
                isHealthy = false;
            }

            return (isHealthy, statusString);
        }
    }
}