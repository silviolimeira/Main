using AutoMapper;
using Sl.GrupoAPI.Data.Dtos;
using Sl.GrupoAPI.Models;

namespace Sl.GrupoAPI.Profiles
{
    public class GrupoProfile : Profile
    {
        public GrupoProfile()
        {
            CreateMap<CreateGrupoDto, Grupo>().ReverseMap();
            CreateMap<ReadGrupoDto, Grupo>().ReverseMap();
            CreateMap<UpdateGrupoDto, Grupo>().ReverseMap();

        }
    }
}
