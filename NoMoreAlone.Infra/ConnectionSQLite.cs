using Dapper;
using Microsoft.Data.Sqlite;
using NoMoreAlone.Infra.Contracts;

namespace NoMoreAlone.Infra
{
    public class ConnectionSQLite : IConnection
    {
        public async Task<T> BuscarUnicoObjetoPorFiltro<T>(string query)
        {
            using (var conexao = new SqliteConnection("Data Source=C:/IFSP/1_semestre/Projeto_Interdisciplinar/DataBase/no_more_alone.db"))
            {
                var result = await conexao.QueryFirstOrDefaultAsync<T>(query);

                return result;
            }
        }

        public async Task<IEnumerable<T>> BuscarTodos<T>(string query)
        {
            using (var conexao = new SqliteConnection("Data Source=C:/IFSP/1_semestre/Projeto_Interdisciplinar/DataBase/no_more_alone.db"))
            {
                var result = await conexao.QueryAsync<T>(query);

                return result;
            }
        }

        public async Task<bool> DeletarPorId(string query)
        {
            using (var conexao = new SqliteConnection("Data Source=C:/IFSP/1_semestre/Projeto_Interdisciplinar/DataBase/no_more_alone.db"))
            {
                var result = await conexao.ExecuteAsync(query);

                return result > 0;
            }
        }

        public async Task<bool> Inserir(string query)
        {
            using (var conexao = new SqliteConnection("Data Source=C:/IFSP/1_semestre/Projeto_Interdisciplinar/DataBase/no_more_alone.db"))
            {
                var result = await conexao.ExecuteAsync(query);

                return result > 0;
            }
        }
    }
}