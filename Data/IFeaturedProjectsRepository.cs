using portfolio_api.Models.GithubModels;

namespace portfolio_api.Data
{
    public interface IFeaturedProjectsRepository
    {
        Task<IEnumerable<FeaturedProjects>> GetAllFeaturedProjectsAsync();
        Task GetFeaturedProjectsByIdAsync(int id);
        Task<FeaturedProjects> GetFeaturedProjectsByNameAsync(string name);
        Task AddFeaturedProjectsAsync(FeaturedProjects project);
        Task DeleteFeaturedProjectsAsync(int id);

    }
}
