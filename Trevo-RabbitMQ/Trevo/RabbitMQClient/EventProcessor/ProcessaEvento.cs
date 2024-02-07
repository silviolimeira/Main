using AutoMapper;
using SL.Trevo_RabbitmQ.Data.Dtos;
using System.Text.Json;

namespace SL.Trevo_RabbitmQ.RabbitMQClient.EventProcessor
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

            var loginUsuarioDto = JsonSerializer.Deserialize<MensagemDto>(mensagem);

            Console.WriteLine("### RECV RABITMQ >>> " + mensagem);
        }
    }
}
