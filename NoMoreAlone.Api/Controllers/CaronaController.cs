using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NoMoreAlone.Api.Dtos.Carona;
using NoMoreAlone.Domain.Models;
using NoMoreAlone.Infra.Contracts;

namespace NoMoreAlone.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CaronaController : ControllerBase
{
    private readonly ICaronaRepository _caronaRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public CaronaController(ICaronaRepository caronaRepository, IUserRepository userRepository, IMapper mapper)
    {
        _caronaRepository = caronaRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dataCarona"></param>
    /// <param name="origemDestino"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> BuscarCaronas([FromQuery] CaronaFiltroDto filtro)
    {
        var caronas = await _caronaRepository.BuscarCaronas(filtro.data > DateTime.MinValue ? filtro.data : null, filtro.origemDestino);

        return Ok(_mapper.Map<List<CaronaReadDto>>(caronas));
    }
    
    [HttpGet("usuario/{usuarioId}")]
    public async Task<IActionResult> BuscarCaronasPorUsuario(int usuarioId)
    {
        var caronas = await _caronaRepository.BuscarCaronasPorDono(usuarioId);

        return Ok(_mapper.Map<List<CaronaReadDto>>(caronas));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> BuscarCaronaPorId(int id)
    {
        var carona = await _caronaRepository.BuscarCaronaPorId(id);

        if (carona == null)
        {
            return NotFound();
        }

        var passageirosDaCarona = await _userRepository.BuscarUsuariosDeUmaCarona(carona.Id);
        carona.Passageiros = passageirosDaCarona;

        return Ok(_mapper.Map<CaronaReadDto>(carona));
    }

    [HttpPost]
    public async Task<IActionResult> CriarCarona([FromBody] CaronaCreateDto caronaCreateDto)
    {
        var caronasDoUsuario = await _caronaRepository.BuscarCaronasPorDono(caronaCreateDto.Dono);

        if(caronasDoUsuario.Any(x => x.Data.Date == caronaCreateDto.Data.Date)) 
            return Conflict(new { error = "Usuário já tem carona cadastrada Hoje" });

        if(caronaCreateDto.Data < DateTime.Now)
            return Conflict(new { error = "Não é possível criar caronas com Data anterior a data atual" });

        var caronaMapeada = _mapper.Map<Carona>(caronaCreateDto);
        var result = await _caronaRepository.InserirCarona(caronaMapeada);

        return Ok();
    }

    [HttpPut]
    public IActionResult Update(CaronaUpdateDto caronaUpdateDto)
    {
        return Ok();
    }
    
    [HttpPut("{idCarona}/passageiro/{idUsuario}/reservar")]
    public async Task<IActionResult> ReservarCarona(int idCarona, int idUsuario)
    {
        var caronaExiste = await _caronaRepository.BuscarCaronaPorId(idCarona);
        if (caronaExiste == null) 
            return NotFound(new { error = "A carona não foi encontrada" });

        var usuarioExiste = await _userRepository.BuscarUserPorId(idUsuario);
        if (usuarioExiste == null) 
            return NotFound(new { error = "Usuário não encontrado" });

        if(caronaExiste.Data < DateTime.Now)
            return Conflict(new { error = "Não é possível reservar caronas com Data anterior a data atual" });

        if(await _caronaRepository.UsuarioJaFazParteDaCarona(idCarona, idUsuario) == true) 
            return Conflict(new { error = "Você já faz parte da carona 😒" });

        var result = await _caronaRepository.ReservarCarona(idCarona, idUsuario);
        
        if (result == true) return Ok();

        return Conflict(new { error = "Houve um erro ao fazer a reserva da carona :( " }); 
    }

    [HttpDelete("{idCarona}/passageiro/{idUsuario}/cancelar")]
    public async Task<IActionResult> CancelarReservaCarona(int idCarona, int idUsuario)
    {
        var caronaExiste = await _caronaRepository.BuscarCaronaPorId(idCarona);
        if (caronaExiste == null) 
            return NotFound(new { error = "A carona não foi encontrada" });

        var usuarioExiste = await _userRepository.BuscarUserPorId(idUsuario);
        if (usuarioExiste == null) 
            return NotFound(new { error = "Usuário não encontrado" });

        if(await _caronaRepository.UsuarioJaFazParteDaCarona(idCarona, idUsuario) == false) 
            return Conflict(new { error = "Passageiro não faz parte da carona 😒" });

        var result = await _caronaRepository.CancelarReservaCarona(idCarona, idUsuario);
        
        if (result == true) return Ok();

        return Conflict(new { error = "Houve um erro ao cancelar a reserva da carona :( " }); 
    }
    
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletarCarona(int id)
    {
        var result = await _caronaRepository.DeletarCaronaPorId(id);

        return Ok();
    }
}
