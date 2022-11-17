using Dapper;
using MySqlConnector;
using NoMoreAlone.Domain.Models;
using NoMoreAlone.Infra.Contracts;

namespace NoMoreAlone.Infra.Repositories
{
    public class CaronaRepository : ICaronaRepository
    {
        private readonly IConnection _connection;

        public CaronaRepository(IConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<Carona>> BuscarCaronas()
        {
            string query = $"SELECT * FROM carona;";

            return await _connection.BuscarTodos<Carona>(query);
        }

        public async Task<Carona> BuscarCaronaPorId(int id)
        {
            string query = $@"SELECT * FROM carona c 
                            INNER JOIN user u ON c.Dono = u.Id 
                            WHERE c.Id = {id};";

            return await _connection.BuscarUnicoObjetoPorCampoUnico<Carona>(query);
        }

        public async Task<IEnumerable<Carona>> BuscarCaronasPorDono(int donoId)
        {
            string query = $"SELECT * FROM carona WHERE Dono = {donoId};";

            return await _connection.BuscarTodos<Carona>(query);
        }

        public async Task<bool> InserirCarona(Carona carona)
        {
            string query = $@"INSERT INTO carona 
                            (Data, PontoPartida, PontoChegada, QuantidadePessoas, Tipo, Dono)
                            VALUES (
                                '{carona.Data.ToString("yyyy-MM-dd HH:mm:ss")}', '{carona.PontoPartida}', '{carona.PontoChegada}', 
                                {carona.QuantidadePessoas}, '{carona.Tipo.ToString()}', {carona.Dono}
                            );";

            return await _connection.Inserir(query);
        }

        public async Task<bool> DeletarCaronaPorId(int id)
        {
            string query = $"delete from carona WHERE id = {id};";

            return await _connection.DeletarPorId(query);
        }
    }
}