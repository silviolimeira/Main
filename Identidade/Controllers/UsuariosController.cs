using AutoMapper;
using IdentidadeAPI.Data.Dtos;
using IdentidadeAPI.GrupoServiceHttpClient;
using IdentidadeAPI.Models;
using IdentidadeAPI.RabbitMqClient;
using IdentidadeAPI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentidadeAPI.Controllers
{

    [ApiController]
    [Route("[Controller]")]
    public class UsuariosController : ControllerBase
    {
        private UsuarioService _usuarioService;
        private IGrupoService _grupoServiceHttpClient;
        private IRabbitMqClient _rabbitMqClient;

        public UsuariosController(UsuarioService usuarioService, IGrupoService grupoServiceHttpClient, IRabbitMqClient rabbitMqClient)
        {
            _usuarioService = usuarioService;
            _grupoServiceHttpClient = grupoServiceHttpClient;
            _rabbitMqClient = rabbitMqClient;
        }

        [HttpPost("cadastro")]
        public async Task<IActionResult> CadastraUsuarioAsync(CreateUsuarioDto dto)
        {
            
            
            //_grupoServiceHttpClient.EnviaUsuario(dto);

            await _usuarioService.CadastraAsync(dto); 
            
            return Ok("Usuário Criado.");
        }
        
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUsuarioDto dto)
        {
            var token = await _usuarioService.LoginUsuario(dto);

            //_grupoServiceHttpClient.EnviaUsuario(dto);
            _rabbitMqClient.PublicaUsuario(dto);
            return Ok(token);
        }

        [HttpGet]
        public string Hello()
        {
            return "Hello World!";
        }

    }
        
}
