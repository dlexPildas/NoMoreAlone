namespace NoMoreAlone.Domain.Models
{
    public class User
    {

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public int Matricula { get; private set; }
        public string Telefone { get; private set; }
        public string Senha { get; private set; }
        public int Semestre { get; private set; }
        public string Curso { get; private set; }

        public User()
        {

        }
    }
}