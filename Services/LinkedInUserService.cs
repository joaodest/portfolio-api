using portfolio_api.Data;
using portfolio_api.Models.LinkedinModels;
using portfolio_api.RabbitMQ.Publishers;

namespace portfolio_api.Services
{
    public class LinkedInUserService : ILinkedInUserService
    {
        private readonly ILinkedInUserRepository _repository;
        private readonly IRabbitMQPublisher _rabbitMQPublisher;

        public LinkedInUserService(ILinkedInUserRepository repository, IRabbitMQPublisher rabbitMQPublisher)
        {
            _repository = repository;
            _rabbitMQPublisher = rabbitMQPublisher;
        }

        public async Task CreateLinkedInUserAsync(LinkedInUser linkedInUser)
        {
            try
            {
                linkedInUser.Username = linkedInUser.Link.Substring(linkedInUser.Link.LastIndexOf('/') + 1);

                await _repository.CreateLinkedInUserAsync(linkedInUser);
                await _repository.SaveChangesAsync();
                _rabbitMQPublisher.PublishObject<LinkedInUser>(linkedInUser);
            }
            catch (HttpRequestException ex)
            {
                Console.Error.WriteLine($"Erro na chamada da API: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Erro na persistência dos dados: {ex.Message}");
            }
        }

    }
}
