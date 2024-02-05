using IdentidadeAPI.Data.Dtos;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Text;
using System.Text.Json;

namespace IdentidadeAPI.GrupoServiceHttpClient
{
    public class GrupoService : IGrupoService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public GrupoService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }
        public async void EnviaUsuario(LoginUsuarioDto dto)
        {
            var conteudoHttp = new StringContent(
                    JsonSerializer.Serialize(dto),
                    Encoding.UTF8,
                    "application/json"
                );
           
            await _httpClient.PostAsync(_configuration["GrupoService"], conteudoHttp);

        }
    }
}
