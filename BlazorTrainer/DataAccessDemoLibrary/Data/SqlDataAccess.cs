using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessDemoLibrary.Data
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _config;

        // This is the constructor for the class. This proejct does NOT contain an appsettings.json file, and a library never should. It should get the configs from the project that is using it
        // This project is using Dapper, which is a micro ORM that allows you to map data from a database to a C# object
        public SqlDataAccess(IConfiguration config)
        {
            _config = config;
        }

        /// <summary>
        /// Get a list of all objects in the table
        /// </summary>
        /// <typeparam name="T">The type of data that you want to have returned</typeparam>
        /// <typeparam name="U">Parmeters for the query</typeparam>
        /// <param name="storedProcedure"></param>
        /// <param name="parameters"></param>
        /// <param name="connString"> This is the NAME of the connection string in the config file, not the actual connectionString</param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> LoadDataAsync<T, U>(string storedProcedure, U parameters, string connStringName = "Default")
        {
            string connString = _config.GetConnectionString(connStringName);

            using (IDbConnection conn = new SqlConnection(connString))
            {
                // Dapper here will take the Type <T> and map it to the data that is returned from the database, by matching the names of the columns ot the names of the T properties
                var rows = await conn.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure); //QueryAsync is a Dapper method that allows you to query the database asynchronously
                return rows;
            }


        }

        /// <summary>
        /// Save Data to the table
        /// </summary>
        /// <param name="storedProcedure"></param>
        /// <param name="parameters"></param>
        /// <param name="connStringName"></param>
        /// <returns></returns>
        public async Task SaveDataAsync(string storedProcedure, object parameters, string connStringName = "Default")
        {
            string connString = _config.GetConnectionString(connStringName);

            using (IDbConnection conn = new SqlConnection(connString))
            {
                await conn.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
