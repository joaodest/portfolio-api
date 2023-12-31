using portfolio_api.Models.GithubModels;

namespace portfolio_api.Data
{
    public interface IGithubUserRepository
    {
        public Task CreateGithubUserAsync(GithubUser githubUser);
        public Task SaveChangesAsync();
    }
}
