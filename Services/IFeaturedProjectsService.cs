using portfolio_api.Models.GithubModels;

namespace portfolio_api.Services
{
    public interface IFeaturedProjectsService
    {
        Task<IEnumerable<FeaturedProjects>> GetAllFeaturedProjectsAsync();
        Task<FeaturedProjects> GetFeaturedProjectByNameAsync(string projectName);
        Task AddFeaturedProjectAsync(FeaturedProjects project);
        Task DeleteFeaturedProjectAsync(int id);
    }
}
