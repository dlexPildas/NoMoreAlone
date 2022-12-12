using NoMoreAlone.Domain.Enuns;

namespace NoMoreAlone.Api.Dtos.Carona
{
    public class CaronaCreateDto
    {
        public DateTime Data { get;  set; }
        public string? PontoPartida { get;  set; }
        public string? PontoChegada { get;  set; }
        public int QuantidadePessoas { get;  set; }

        public double Preco { get; set; }
        public TipoCarona Tipo { get;  set; }
        public int Dono { get;  set; }
    }
}