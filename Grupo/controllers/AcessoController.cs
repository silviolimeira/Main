using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.Json;
using System.Collections;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace Sl.GrupoAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AcessoController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAsync([FromHeader] string access_token)
        {
            var handler = new JwtSecurityTokenHandler();
            try
            {
                var claims = handler.ReadJwtToken(access_token);
                var lista = claims.Claims.ToList();
                var dataNascimento = lista[2].Value;
            } catch (Exception ex)
            {
                return Unauthorized();
            }

            return Ok("Acesso Permitido.");
        }
    }
}
