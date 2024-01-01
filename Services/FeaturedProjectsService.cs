using portfolio_api.Data;
using portfolio_api.Models.GithubModels;

namespace portfolio_api.Services
{
    public class FeaturedProjectsService : IFeaturedProjectsService
    {

        private readonly IFeaturedProjectsRepository _repository;

        public FeaturedProjectsService(IFeaturedProjectsRepository repository)
        {
            _repository = repository;
        }

        public async Task AddFeaturedProjectAsync(FeaturedProjects project)
        {
            if (project == null)
            {
                throw new ArgumentNullException(nameof(project));
            }

            await _repository.AddFeaturedProjectsAsync(project);
        }

        public async Task DeleteFeaturedProjectAsync(int id)
        {
            try
            {
                var project = _repository.GetFeaturedProjectsByIdAsync(id);
                if (project == null)
                {
                    throw new ArgumentNullException(nameof(project));
                }
                await _repository.DeleteFeaturedProjectsAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possível deletar o projeto: {ex.Message}");
            }
        }

        public async Task<IEnumerable<FeaturedProjects>> GetAllFeaturedProjectsAsync()
        {
            try
            {
                var proj = await _repository.GetAllFeaturedProjectsAsync();

                if (proj == null)
                {
                    throw new Exception("Não há projetos cadastrados");
                }
                return proj;
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possível obter os projetos: {ex.Message}");
            }
        }

        public Task<FeaturedProjects> GetFeaturedProjectByNameAsync(string projectName)
        {
            try
            {
                var proj = _repository.GetFeaturedProjectsByNameAsync(projectName);
                if (proj == null)
                {
                    throw new Exception("Não há projeto cadastrado com este nome");
                }
                return proj;
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possível obter o projeto: {ex.Message}");
            }
        }

    }
}
