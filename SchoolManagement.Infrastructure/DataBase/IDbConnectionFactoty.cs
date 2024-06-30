using System.Data;

namespace SchoolManagement.Infrastructure.DataBase
{
    /// <summary>
    /// Contrat de création d'une connexion à un serveur de base de données.
    /// </summary>
    public  interface IDbConnectionFactoty
    {
        public IDbConnection CreateConnection();
        public Task<IDbConnection> CreateConnectionAsync();
    }
}
