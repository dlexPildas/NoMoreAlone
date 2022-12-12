using NoMoreAlone.Api.Dtos.User;
using NoMoreAlone.Domain.Enuns;

namespace NoMoreAlone.Api.Dtos.Carona
{
    public class CaronaReadDto
    {
        public int Id { get; set; }
        public DateTime Data { get;  set; }
        public string? PontoPartida { get;  set; }
        public string? PontoChegada { get;  set; }
        public int QuantidadePessoas { get;  set; }
        public double Preco { get; set; }
        public string? Tipo { get;  set; }
        public int Dono { get; set; }

        public List<UserReadDto>? Passageiros { get; set; }
    }
}