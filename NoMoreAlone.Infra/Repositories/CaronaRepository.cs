using Dapper;
using MySqlConnector;
using NoMoreAlone.Domain.Models;
using NoMoreAlone.Infra.Contracts;

namespace NoMoreAlone.Infra.Repositories
{
    public class CaronaRepository : ICaronaRepository
    {
        private readonly Connection _connection;

        public CaronaRepository(Connection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<Carona>> BuscarCaronas()
        {
            string query = $"SELECT * FROM carona;";

            using (MySqlConnection conexao = new MySqlConnection(_connection.connectionString))
            {
                return await conexao.QueryAsync<Carona>(query); ;
            }
        }

        public async Task<Carona> BuscarCaronaPorId(int id)
        {
            string query = $@"SELECT * FROM carona c inner join user u on c.Dono = u.Id WHERE c.Id = {id};";

            using (MySqlConnection conexao = new MySqlConnection(_connection.connectionString))
            {
                var result = await conexao.QueryAsync<Carona, User, Carona>(
                    query,
                    (c, u) =>
                    {
                        if (u != null) c.DonoCarona = u;
                        return c;
                    }
                );
                return result?.FirstOrDefault();
            }
        }

        public async Task<bool> InserirCarona(Carona carona)
        {
            string query = $@"INSERT INTO carona 
                            (Data, PontoPartida, PontoChegada, QuantidadePessoas, Tipo, Dono)
                            VALUES ('{carona.Data.ToString("yyyy-MM-dd HH:mm:ss")}', '{carona.PontoPartida}', '{carona.PontoChegada}', {carona.QuantidadePessoas}, '{carona.Tipo.ToString()}', {carona.Dono});";

            using (MySqlConnection conexao = new MySqlConnection(_connection.connectionString))
            {
                return await conexao.ExecuteAsync(query) > 0;
            }
        }

        public async Task<bool> DeletarCaronaPorId(int id)
        {
            string query = $"delete from carona WHERE id = {id};";

            using (MySqlConnection conexao = new MySqlConnection(_connection.connectionString))
            {
                return await conexao.ExecuteAsync(query) > 0;
            }
        }
    }
}