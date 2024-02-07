﻿using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using SL.Trevo_RabbitmQ.RabbitMQClient.EventProcessor;
using System.Text;

namespace SL.Trevo_RabbitmQ.RabbitMQClient
{
    public class RabbitMqSubscriber : BackgroundService
    {
        private readonly IConfiguration _configuration;
        private readonly string _nomeDaFila;
        private readonly IConnection _connection;
        private IChannel _channel;
        private IProcessaEvento _processaEvento;

        public RabbitMqSubscriber(IConfiguration configuration, IProcessaEvento processaEvento)
        {
            _processaEvento = processaEvento;
            _configuration = configuration;
            _connection = new ConnectionFactory()
            {
                HostName = _configuration["RabbitMqHost"],
                Port = Int32.Parse(_configuration["RabbitMqPort"])
            }.CreateConnection();
            _channel = _connection.CreateChannel();
            _channel.ExchangeDeclare(exchange: "trigger", type: ExchangeType.Fanout);
            _nomeDaFila = _channel.QueueDeclare().QueueName;
            _channel.QueueBind(queue: _nomeDaFila, exchange: "trigger", routingKey: "");
            
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumidor = new EventingBasicConsumer(_channel);

            consumidor.Received += (ModuleHandle, ea) =>
            {
                var body = ea.Body;
                var mensagem = Encoding.UTF8.GetString(body.ToArray());
                _processaEvento.Processa(mensagem);
            };

            _channel.BasicConsume(queue: _nomeDaFila, autoAck: true, consumer: consumidor);

            return Task.CompletedTask;

        }

    }
}
