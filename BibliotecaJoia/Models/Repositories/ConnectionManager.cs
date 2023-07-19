using BibliotecaJoia.Models.Contracts.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Models.Repositories
{
    public class ConnectionManager : IConnectionManager
    {
        //biblioteca
        private static string _connectionNmae = "biblioteca";
        private static SqlConnection connection = null;
        
        public ConnectionManager(IConfiguration configuration)
        {
            var connStr = configuration.GetConnectionString(_connectionNmae);
            if (connection == null)
                connection = new SqlConnection(connStr);
        }

        public SqlConnection GetConnection()
        {
            return connection;
        }
    }
}
