using portfolio_api.Data;
using portfolio_api.Models.GithubModels;

namespace portfolio_api.Services
{
    public class GithubUserService : IGithubUserService
    {
        private readonly IGithubUserRepository _githubUserRepository;

        public GithubUserService(IGithubUserRepository githubUserRepository)
        {
            _githubUserRepository = githubUserRepository;
        }

        public async Task CreateGithubUserAsync(GithubUser githubUser)
        {
            try
            {
                await _githubUserRepository.CreateGithubUserAsync(githubUser);
                await _githubUserRepository.SaveChangesAsync();
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
