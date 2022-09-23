namespace NoMoreAlone.Domain.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Code { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Ride> Rides { get; private set; }
        public List<Agglomeration> Agglomerations { get; private set; }

        public User()
        {

        }

        public void UpdateUser(string name, string code, string email, string password) 
        {
            Name = name;
            Code = code;
            Password = password;
        }

        



    }
}