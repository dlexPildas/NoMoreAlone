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
    private readonly IMapper _mapper;

    public CaronaController(ICaronaRepository caronaRepository, IMapper mapper)
    {
        _caronaRepository = caronaRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var caronas = await _caronaRepository.BuscarCaronas();
        
        return Ok(caronas);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _caronaRepository.BuscarCaronaPorId(id);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CaronaCreateDto caronaCreateDto)
    {
        var caronaMapeada = _mapper.Map<Carona>(caronaCreateDto);
        var result = await _caronaRepository.InserirCarona(caronaMapeada);

        return Ok();
    }

    [HttpPut]
    public IActionResult Update(CaronaUpdateDto caronaUpdateDto)
    {
        return Ok();
    }
    
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletarCarona(int id)
    {
        var result = await _caronaRepository.DeletarCaronaPorId(id);

        return Ok();
    }
}
