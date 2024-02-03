using AutoMapper;
using IdentidadeAPI.Data.Dtos;
using IdentidadeAPI.Models;

namespace IdentidadeAPI.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<CreateUsuarioDto, Usuario>();
        }
    }
}
