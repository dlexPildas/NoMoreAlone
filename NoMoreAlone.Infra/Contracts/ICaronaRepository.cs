using NoMoreAlone.Domain.Models;

namespace NoMoreAlone.Infra.Contracts
{
    public interface ICaronaRepository
    {
        Task<IEnumerable<Carona>> BuscarCaronas();
        
        Task<Carona> BuscarCaronaPorId(int id);
        Task<IEnumerable<Carona>> BuscarCaronasPorDono(int donoId);

        Task<bool> InserirCarona(Carona carona);
        
        Task<bool> DeletarCaronaPorId(int id);
        Task<bool> ReservarCarona(int idCarona, int idPassageiro);
    }
}