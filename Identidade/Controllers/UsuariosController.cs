using AutoMapper;
using IdentidadeAPI.Data.Dtos;
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

        public UsuariosController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("cadastro")]
        public async Task<IActionResult> CadastraUsuarioAsync(CreateUsuarioDto dto)
        {
            await _usuarioService.CadastraAsync(dto);
            
            return Ok("Usuário Criado.");
        }
        
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUsuarioDto dto)
        {
            var token = await _usuarioService.LoginUsuario(dto);

            return Ok(token);
        }

        [HttpGet]
        public string Hello()
        {
            return "Hello World!";
        }

    }
        
}
