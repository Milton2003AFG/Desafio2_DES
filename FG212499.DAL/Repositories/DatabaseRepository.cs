using Dapper;
using FG212499.Common;
using FG212499.DAL.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FG212499.DAL.Repositories
{
    public class DatabaseRepository(IOptions<AppSettings> appSettings) : IDatabaseRepository
    {
        private readonly string _connectionString = appSettings.Value.ConnectionString;

        public async Task<List<T>> GetDataByQueryAsync<T>(string query, DynamicParameters? parameters = null)
        {
            await using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            var result = await connection.QueryAsync<T>(query, parameters);
            return result.ToList();
        }

        public async Task<int> InsertAsync(string query, DynamicParameters? parameters = null)
        {
            await using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            return await connection.QuerySingleOrDefaultAsync<int>(query, parameters);
        }

        public async Task<T?> UpdateAsync<T>(string query, DynamicParameters? parameters = null)
        {
            await using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            var result = await connection.QueryAsync<T>(query, parameters);
            return result.FirstOrDefault();
        }

        public async Task<bool> DeleteAsync(string query, DynamicParameters? parameters = null)
        {
            await using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            var rowsAffected = await connection.ExecuteAsync(query, parameters);
            return rowsAffected > 0;
        }
    }
}
