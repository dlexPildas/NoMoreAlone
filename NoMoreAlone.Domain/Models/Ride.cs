namespace NoMoreAlone.Domain.Models
{
    public class Ride
    {
        public int Id { get; private set; }

        public List<User> Users { get; private set; }

        public Ride() { }
    }
}