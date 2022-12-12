using NoMoreAlone.Domain.Enuns;

namespace NoMoreAlone.Domain.Models
{
    public class Carona
    {
        public int Id { get; private set; }
        public DateTime Data { get; private set; }
        public string PontoPartida { get; private set; }
        public string PontoChegada { get; private set; }
        public int QuantidadePessoas { get; private set; }
        public TipoCarona Tipo { get; private set; }
        public double Preco { get; set; }
        public int Dono { get; private set; }
        public User DonoCarona { get; set; }
        public List<User>? Passageiros { get; set; }

        public Carona() {}
    }
}