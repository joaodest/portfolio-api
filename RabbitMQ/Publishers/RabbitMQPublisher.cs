using portfolio_api.Models.GithubModels;
using RabbitMQ.Client;
using Serilog;
using System.Text;
using System.Text.Json;

namespace portfolio_api.RabbitMQ.Publishers
{
    public class RabbitMQPublisher : IRabbitMQPublisher, IDisposable
    {
        private readonly IConfiguration _configuration;
        private readonly IConnection _connection;
        private readonly IModel _channel;

        private bool _disposed = false;

        public RabbitMQPublisher(IConfiguration configuration)
        {
            _configuration = configuration;
            _connection = new ConnectionFactory()
            {
                HostName = _configuration["RabbitMqHost"],
                Port = _configuration.GetValue<int>("RabbitMqPort"),
            }.CreateConnection();

            _channel = _connection.CreateModel();

            _channel.ExchangeDeclare(exchange: "trigger", type: ExchangeType.Fanout);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                if (disposing)
                {
                    _channel?.Dispose();
                    _connection?.Dispose();
                }
                _disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void PublishObject<T>(Object obj)
        {
            try
            {
                string msg = JsonSerializer.Serialize(obj);
                var body = Encoding.UTF8.GetBytes(msg);

                Log.Information($"Publicando mensagem: {msg}");
                _channel.BasicPublish(exchange: "trigger",
                                     routingKey: "",
                                     basicProperties: null,
                                     body: body);
                Log.Information("Mensagem publicada com sucesso.");
            }
            catch (Exception ex)
            {
                Log.Error($"Erro ao publicar mensagem: {ex.Message}");
            }

        }

    }
}
