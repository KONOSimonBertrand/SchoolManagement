using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using SchoolManagement.Core.Model;
using System.Data;

namespace SchoolManagement.Infrastructure.DataBase
{

    /// <summary>
    /// Cette classe permet de créer une connexion à un serveur de base de données MySql.
    /// </summary>
    public class MySqlConnectionFactory : IDbConnectionFactory
    {
        private readonly ClientApp _clientApp;
        private readonly ILogger<MySqlConnectionFactory> _logger;
        public MySqlConnectionFactory(ClientApp clientApp, ILogger<MySqlConnectionFactory> logger)
        {
            _clientApp = clientApp;
            _logger = logger;
        }
        public  IDbConnection CreateConnection()
        {            
            var connection = new MySqlConnection(_clientApp.ConnectionString);
            connection.Open();
            return connection;
        }

        public async Task<IDbConnection> CreateConnectionAsync()
        {
            var connection = new MySqlConnection(_clientApp.ConnectionString);
            await connection.OpenAsync();
            return connection;
        }
    } 
}


