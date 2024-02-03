using AutoMapper;
using IdentidadeAPI.Data.Dtos;
using IdentidadeAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace IdentidadeAPI.Services
{
    public class UsuarioService
    {
        public IMapper _mapper;
        public UserManager<Usuario> _userManager;
        public SignInManager<Usuario> _signManager;
        public TokenService _tokenService;

        public UsuarioService(IMapper mapper, UserManager<Usuario> userManager, SignInManager<Usuario> signManager, TokenService tokenService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signManager = signManager;
            _tokenService = tokenService;
        }

        public async Task CadastraAsync(CreateUsuarioDto dto)
        {
            Usuario usuario = _mapper.Map<Usuario>(dto);
            var resultado = await _userManager.CreateAsync(usuario, dto.Password);
            if (!resultado.Succeeded)
            {
                throw new ApplicationException("Falha ao cadastrar usuário.");
            }

        }

        public async Task<string> LoginUsuario(LoginUsuarioDto dto)
        {
            var resultado = await _signManager.PasswordSignInAsync(dto.Username, dto.Password, false, false);
            if (!resultado.Succeeded)
            {
                throw new ApplicationException("Usuário não autenticado.");
            }

            var usuario = _signManager.UserManager.Users.FirstOrDefault(user => user.NormalizedUserName == dto.Username.ToUpper());

            var token = _tokenService.GenerateToken(usuario);

            return token;
        }
    }
}