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

        public async Task<IEnumerable<Carona>> BuscarCaronas(DateTime? data, string? origemDestino)
        {
            string query = @$"SELECT * FROM carona
                              WHERE
                                1=1 
                                {(data != null ? $"AND data between '{data.Value.ToString("yyyy-MM-dd 00:00:00")}' AND '{data.Value.ToString("yyyy-MM-dd 23:59:59")}'" : "")}  
                                {(!string.IsNullOrEmpty(origemDestino) ? $"AND PontoPartida like '%{origemDestino}%' OR PontoChegada like '%{origemDestino}%'"  : "")} ;";

            return await _connection.BuscarTodos<Carona>(query);
        }

        public async Task<Carona> BuscarCaronaPorId(int id)
        {
            string query = $@"SELECT * FROM carona c 
                            WHERE c.Id = {id};";

            return await _connection.BuscarUnicoObjetoPorFiltro<Carona>(query);
        }

        public async Task<IEnumerable<Carona>> BuscarCaronasPorDono(int donoId)
        {
            string query = $"SELECT * FROM carona WHERE Dono = {donoId};";

            return await _connection.BuscarTodos<Carona>(query);
        }

        public async Task<bool> InserirCarona(Carona carona)
        {
            string query = $@"INSERT INTO carona 
                            (Data, PontoPartida, PontoChegada, QuantidadePessoas, Tipo, Preco, Dono)
                            VALUES (
                                '{carona.Data.ToString("yyyy-MM-dd HH:mm:ss")}', '{carona.PontoPartida}', '{carona.PontoChegada}', 
                                {carona.QuantidadePessoas}, '{carona.Tipo.ToString()}', '{carona.Preco.ToString().Replace(',', '.')}', {carona.Dono}
                            );";

            return await _connection.Inserir(query);
        }

        public async Task<bool> DeletarCaronaPorId(int id)
        {
            string query = $"delete from carona WHERE id = {id};";

            return await _connection.DeletarPorId(query);
        }

        public async Task<bool> ReservarCarona(int idCarona, int idPassageiro)
        {
            string query = $@"INSERT INTO carona_user (IdUsuario, IdCarona, DataReserva)
                            VALUES (
                                {idPassageiro}, {idCarona}, '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}'
                            );";

            return await _connection.Inserir(query);
        }

        public async Task<bool> UsuarioJaFazParteDaCarona(int idCarona, int idUsuario)
        {
            string query = $"SELECT * FROM carona_user WHERE IdUsuario = {idUsuario} AND IdCarona = {idCarona};";

            Carona carona = await _connection.BuscarUnicoObjetoPorFiltro<Carona>(query);

            if(carona != null) return true;

            return false;
        }
    }
}