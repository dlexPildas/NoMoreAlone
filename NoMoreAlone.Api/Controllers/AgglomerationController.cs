using Microsoft.AspNetCore.Mvc;
using NoMoreAlone.Api.Dtos.Agglomeration;

namespace NoMoreAlone.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AgglomerationController : ControllerBase
    {
        public AgglomerationController()
        {

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
        public IActionResult Create(AgglomerationCreateDto agglomerationCreateDto)
        {
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(AgglomerationUpdateDto agglomerationUpdateDto)
        {
            return Ok();
        }
    }
}