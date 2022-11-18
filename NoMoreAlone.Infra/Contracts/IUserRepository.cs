using NoMoreAlone.Domain.Models;

namespace NoMoreAlone.Infra.Contracts
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> BuscarUsers();
        
        Task<User> BuscarUserPorId(int id);

        Task<bool> InserirUser(User User);
        
        Task<bool> DeletarUserPorId(int id);
    }
}