using portfolio_api.Models.GithubModels;

namespace portfolio_api.Services
{
    public interface IGithubUserService
    {
        public Task CreateGithubUserAsync(GithubUser githubUser);
    }
}
