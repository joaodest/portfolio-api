using portfolio_api.Data;
using portfolio_api.Models.GithubModels;
using portfolio_api.RabbitMQ.Publishers;

namespace portfolio_api.Services
{
    public class GithubUserService : IGithubUserService
    {
        private readonly IGithubUserRepository _githubUserRepository;
        private readonly IRabbitMQPublisher _rabbitMQPublisher;

        public GithubUserService(IGithubUserRepository githubUserRepository, IRabbitMQPublisher rabbitMQPublisher)
        {
            _githubUserRepository = githubUserRepository;
            _rabbitMQPublisher = rabbitMQPublisher;
        }

        public async Task CreateGithubUserAsync(GithubUser githubUser)
        {
            try
            {
                await _githubUserRepository.CreateGithubUserAsync(githubUser);
                await _githubUserRepository.SaveChangesAsync();

                
                _rabbitMQPublisher.PublishObject<GithubUser>(githubUser);
                
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
