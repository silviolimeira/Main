namespace SL.Trevo_RabbitmQ.RabbitMQClient.EventProcessor
{
    public interface IProcessaEvento
    {
        void Processa(string mensagem);
    }
}
