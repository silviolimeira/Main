using AutoMapper;
using IdentidadeAPI.Data.Dtos;
using IdentidadeAPI.GrupoServiceHttpClient;
using IdentidadeAPI.Models;
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

        public UsuariosController(UsuarioService usuarioService, IGrupoService grupoServiceHttpClient)
        {
            _usuarioService = usuarioService;
            _grupoServiceHttpClient = grupoServiceHttpClient;
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

            _grupoServiceHttpClient.EnviaUsuario(dto);

            return Ok(token);
        }

        [HttpGet]
        public string Hello()
        {
            return "Hello World!";
        }

    }
        
}
