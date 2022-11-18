namespace NoMoreAlone.Api.Dtos.User
{
    public class UserCreateDto
    {
        public string Nome { get; set; }
        public int Matricula { get; set; }
        public string Telefone { get; set; }
        public int Semestre { get; set; }
        public string Curso { get; set; }
    }
}