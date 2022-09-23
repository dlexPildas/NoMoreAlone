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
            var user = new User() 
            {
                Code = "123456",
                Email = "Daniel@teste.com",
                Name = "Daniel",
                Password = "teste"
            };

            var userMapped = _mapper.Map<UserCreateDto>(user);

            return Ok(userMapped);
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