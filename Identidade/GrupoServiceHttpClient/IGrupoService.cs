using IdentidadeAPI.Data.Dtos;

namespace IdentidadeAPI.GrupoServiceHttpClient
{
    public interface IGrupoService
    {
        public void EnviaUsuario(LoginUsuarioDto dto);
    }
}