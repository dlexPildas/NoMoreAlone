
using System.Data;
using Microsoft.Data.SqlClient;
using NoMoreAlone.Infra.Contracts;

namespace NoMoreAlone.Infra
{
    public class Connection : IConnection
    {
        Task<IEnumerable<T>> IConnection.BuscarTodos<T>(string query)
        {
            throw new NotImplementedException();
        }

        Task<T> IConnection.BuscarUnicoObjetoPorFiltro<T>(string query)
        {
            throw new NotImplementedException();
        }

        Task<bool> IConnection.DeletarPorId(string query)
        {
            throw new NotImplementedException();
        }

        Task<bool> IConnection.Inserir(string query)
        {
            throw new NotImplementedException();
        }
    }
}