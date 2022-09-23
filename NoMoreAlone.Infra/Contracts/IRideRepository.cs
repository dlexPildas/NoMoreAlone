using NoMoreAlone.Domain.Models;

namespace NoMoreAlone.Infra.Contracts
{
    public interface IRideRepository
    {
        Task<IEnumerable<Ride>> GetRides(int id);
        
        Task<Ride> GetRideById(int id);
    }
}