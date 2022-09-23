using Dapper;
using NoMoreAlone.Domain.Models;
using NoMoreAlone.Infra.Contracts;

namespace NoMoreAlone.Infra.Repositories
{
    public class RideRepository : IRideRepository
    {
        private readonly IConnection _connection;

        public RideRepository(IConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<Ride>> GetRides(int id)
        {
            string query = $"SELECT * FROM ride;";
            
            var rides = await _connection.GetConnection().QueryAsync<Ride>(query);

            return rides;
        }

        public async Task<Ride> GetRideById(int id)
        {
            string query = $"SELECT * FROM ride WHERE id = {id};";
            
            Ride ride = await _connection.GetConnection().QuerySingleOrDefaultAsync<Ride>(query);

            return ride;
        }
    }
}