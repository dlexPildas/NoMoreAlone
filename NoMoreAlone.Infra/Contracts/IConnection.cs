using System.Data;

namespace NoMoreAlone.Infra.Contracts
{
    public interface IConnection
    {
        IDbConnection GetConnection();
    }
}