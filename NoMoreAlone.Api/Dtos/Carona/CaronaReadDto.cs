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
        public string? Tipo { get;  set; }
    }
}