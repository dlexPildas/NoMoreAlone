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

            var user = await _connection.BuscarUnicoObjetoPorFiltro<User>(query);

            return user;
        }

        public async Task<IEnumerable<User>> BuscarUsers()
        {
            string query = $"SELECT * FROM user;";

            var users = await _connection.BuscarTodos<User>(query);

            return users;
        }

        public async Task<User> BuscarUsuarioPorMatriculaESenha(string senha, int matricula)
        {
            string query = $"SELECT * FROM user WHERE Senha = '{senha}' AND Matricula = {matricula};";

            var user = await _connection.BuscarUnicoObjetoPorFiltro<User>(query);

            return user;
        }

        public async Task<List<User>> BuscarUsuariosDeUmaCarona(int idCarona)
        {
            string query = @$"select u.* from carona_user ca 
                            inner join user u on ca.IdUsuario = u.Id
                            where ca.IdCarona = {idCarona};";

            var users = await _connection.BuscarTodos<User>(query);

            if(users == null) return new List<User> {};

            return users.ToList();
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