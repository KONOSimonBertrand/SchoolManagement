using System.Data;

namespace SchoolManagement.Infrastructure.DataBase
{
    /// <summary>
    /// Contrat de création d'une connexion à un serveur de base de données.
    /// </summary>
    public  interface IDbConnectionFactory
    {
        public IDbConnection CreateConnection();
        public Task<IDbConnection> CreateConnectionAsync();
    }
}
