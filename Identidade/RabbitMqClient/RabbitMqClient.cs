using IdentidadeAPI.Data.Dtos;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace IdentidadeAPI.RabbitMqClient
{
    public class RabbitMqClient : IRabbitMqClient
    {
        private readonly IConfiguration _configuration;
        private readonly IConnection _connection;
        private readonly IChannel _channel;

        public RabbitMqClient(IConfiguration configuration)
        {
            _configuration = configuration;
            _connection = new ConnectionFactory()
            {
                HostName = _configuration["RabbitMqHost"],
                Port = Int32.Parse(_configuration["RabbitMqPort"])
            }.CreateConnection();
            _channel = _connection.CreateChannel();
            _channel.ExchangeDeclare(exchange: "trigger", type: ExchangeType.Fanout);

        }

        public void PublicaUsuario(LoginUsuarioDto dto)
        {
            string mensagem = JsonSerializer.Serialize(dto);
            var body = Encoding.UTF8.GetBytes(mensagem);
            _channel.BasicPublish(
                exchange: "trigger",
                routingKey: "",
                body: body);

        }
    }
}
