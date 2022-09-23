using Microsoft.AspNetCore.Mvc;
using NoMoreAlone.Api.Dtos.Ride;
using NoMoreAlone.Domain.Models;
using NoMoreAlone.Infra.Contracts;

namespace NoMoreAlone.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class RideController : ControllerBase
{
    private readonly IRideRepository _rideRepository;

    public RideController(IRideRepository rideRepository)
    {
        _rideRepository = rideRepository;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _rideRepository.GetRideById(1);

        return Ok(result);
    }

    [HttpPost]
    public IActionResult Create(RideCreateDto rideCreateDto)
    {
        return Ok();
    }

    [HttpPut]
    public IActionResult Update(RideUpdateDto rideUpdateDto)
    {
        return Ok();
    }
}
