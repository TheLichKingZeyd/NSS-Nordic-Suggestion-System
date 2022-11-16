using NordicDoorSuggestionSystem.Entities;
using MySqlConnector;
using System.Data;
using System.Data.Common;

namespace NordicDoorSuggestionSystem.DataAccess
{
    public class SqlConnector : ISqlConnector
    {
        private readonly IConfiguration config;

        public SqlConnector(IConfiguration config)
        {
            this.config = config;
        }

        public IDbConnection GetDbConnection()
        {
            return new MySqlConnection(config.GetConnectionString("MariaDb"));
        }
          
    }
}