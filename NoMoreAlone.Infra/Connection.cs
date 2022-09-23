
using System.Data;
using Microsoft.Data.SqlClient;
using NoMoreAlone.Infra.Contracts;

namespace NoMoreAlone.Infra
{
    public class Connection : IConnection
    {
        private readonly IDbConnection  _connection;
        public Connection()
        {
            _connection = new SqlConnection("");
        }

        public IDbConnection GetConnection()
        {
            return _connection;
        }
    }
}