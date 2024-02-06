using AutoMapper;
using Sl.GrupoAPI.Data.Dtos;
using System.Text.Json;

namespace Sl.GrupoAPI.EventProcessor
{
    public class ProcessaEvento : IProcessaEvento
    {
        private readonly IMapper _mapper;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public ProcessaEvento(IMapper mapper, IServiceScopeFactory serviceScopeFactory)
        {
            _mapper = mapper;
            _serviceScopeFactory = serviceScopeFactory;
        }
        public void Processa(string mensagem)
        {
            using var scope = _serviceScopeFactory.CreateScope();

            var loginUsuarioDto = JsonSerializer.Deserialize<LoginUsuarioDto>(mensagem);

            Console.WriteLine("### RECV RABITMQ >>> " + mensagem);
        }
    }
}
