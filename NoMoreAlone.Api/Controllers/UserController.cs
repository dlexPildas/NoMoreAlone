using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NoMoreAlone.Api.Dtos.User;
using NoMoreAlone.Domain.Models;

namespace NoMoreAlone.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;

        public UserController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {            
            return Ok();
        }

        [HttpPost]
        public IActionResult Create(UserCreateDto userCreateDto)
        {
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(UserUpdateDto userUpdateDto)
        {
            return Ok();
        }
    }
}