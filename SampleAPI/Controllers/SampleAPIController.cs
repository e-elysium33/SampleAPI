using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SampleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleAPIController : ControllerBase
    {
        [HttpGet("GetDetails")]
        public IActionResult GetDetails()
        {
            var details = new[]
            {
                new { Id = 1, Name = "Abc abc", Email = "abc@abc.abc" },
                new { Id = 2, Name = "Def def", Email = "def@def.def" }
            };

            return Ok(details);
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
