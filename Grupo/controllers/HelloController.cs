using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Sl.GrupoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloController : ControllerBase
    {
        [HttpGet]
        public string Hello()
        {
            return "Hello World!";
        }

        [HttpPost]
        public IActionResult Post(string mensagem)
        {
            Console.WriteLine("### GRUPO >>> " + mensagem);
            return Ok("Grupo - mensagem recebida: " + mensagem);
        }
    }
}
