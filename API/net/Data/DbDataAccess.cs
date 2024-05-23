using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
namespace net.Data
{
    public class DbDataAccess : IDbDataAccess
    {
        private readonly IConfiguration _configuration;

        public DbDataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<T>> GetDataAsync<T>(
            string sqlQuery, object parameters = null, string connection = "default")
        {
            using IDbConnection dbConnection =
                new SqlConnection(_configuration.GetConnectionString(connection));

            return await dbConnection.QueryAsync<T>(sqlQuery, parameters);
        }


        public async Task SaveDataAsync(
            string sqlQuery, object parameters, string connection = "default")
        {
            using IDbConnection dbConnection =
                new SqlConnection(_configuration.GetConnectionString(connection));

            await dbConnection.ExecuteAsync(sqlQuery, parameters);
        }

       
    }
}
