using IdentidadeAPI.Data.Dtos;

namespace IdentidadeAPI.RabbitMqClient
{
    public interface IRabbitMqClient
    {
        void PublicaUsuario(LoginUsuarioDto dto);
    }
}