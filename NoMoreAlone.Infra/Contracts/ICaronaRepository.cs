using NoMoreAlone.Domain.Models;

namespace NoMoreAlone.Infra.Contracts
{
    public interface ICaronaRepository
    {
        Task<IEnumerable<Carona>> BuscarCaronas();
        
        Task<Carona> BuscarCaronaPorId(int id);

        Task<bool> InserirCarona(Carona carona);
        
        Task<bool> DeletarCaronaPorId(int id);
    }
}