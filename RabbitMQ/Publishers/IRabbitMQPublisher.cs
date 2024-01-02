using portfolio_api.Models.GithubModels;

namespace portfolio_api.RabbitMQ.Publishers
{
    public interface IRabbitMQPublisher
    {
        public void PublishObject<T>(Object obj);

    }
}
