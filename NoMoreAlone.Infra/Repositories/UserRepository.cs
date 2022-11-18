using NoMoreAlone.Domain.Models;
using NoMoreAlone.Infra.Contracts;

namespace NoMoreAlone.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IConnection _connection;

        public UserRepository(IConnection connection)
        {
            _connection = connection;
        }

        public async Task<User> BuscarUserPorId(int id)
        {
            string query = $"SELECT * FROM user WHERE Id = {id};";

            var user = await _connection.BuscarUnicoObjetoPorCampoUnico<User>(query);

            return user;
        }

        public async Task<IEnumerable<User>> BuscarUsers()
        {
            string query = $"SELECT * FROM user;";

            var users = await _connection.BuscarTodos<User>(query);

            return users;
        }

        public async Task<bool> DeletarUserPorId(int id)
        {
            string query = $"DELETE FROM user WHERE Id = {id};";

            return await _connection.DeletarPorId(query);
        }

        public async Task<bool> InserirUser(User user)
        {
            string query = @$"insert into user 
                (Nome, Matricula, Telefone, Semestre, Curso)
                values ('{user.Nome}', {user.Matricula}, '{user.Telefone}', {user.Semestre}, '{user.Curso}')";

            return await _connection.Inserir(query);
        }
    }
}