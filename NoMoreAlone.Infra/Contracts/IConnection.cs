using System.Data;

namespace NoMoreAlone.Infra.Contracts
{
    public interface IConnection
    {
        Task<T> BuscarUnicoObjetoPorFiltro<T>(string query);

        Task<bool> Inserir(string query);

        Task<bool> DeletarPorId(string query);

        Task<IEnumerable<T>> BuscarTodos<T>(string query);
    }
}