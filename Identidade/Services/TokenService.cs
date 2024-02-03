﻿

using IdentidadeAPI.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IdentidadeAPI.Services
{
    public class TokenService
    {
        private IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateToken(Usuario usuario)
        {
            
            Claim[] clains = new Claim[]
            {
                new Claim("username", usuario.UserName),
                new Claim("id", usuario.Id),
                new Claim(ClaimTypes.DateOfBirth, usuario.DataNascimento.ToString())
            };

            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SymmetricSecurityKey"]));

            var signCredentials = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);


            var token = new JwtSecurityToken(
                    expires: DateTime.Now.AddMinutes(10),
                    claims: clains,
                    signingCredentials: signCredentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}