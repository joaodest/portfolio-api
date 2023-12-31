using portfolio_api.Models.GithubModels;

namespace portfolio_api.Data
{
    public class GithubUserRepository : IGithubUserRepository
    {
        private readonly AppDbContext _context;

        public GithubUserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateGithubUserAsync(GithubUser githubUser)
        {
            if (githubUser.Equals(null))
                throw new ArgumentNullException(nameof(githubUser));

            await _context.GithubUsers.AddAsync(githubUser);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
