using Microsoft.EntityFrameworkCore;
using portfolio_api.Models.GithubModels;

namespace portfolio_api.Data
{
    public class FeaturedProjectsRepository : IFeaturedProjectsRepository
    {
        private readonly AppDbContext _context;

        public FeaturedProjectsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FeaturedProjects>> GetAllFeaturedProjectsAsync()
        {
            return await _context.FeaturedProjects.ToListAsync();
        }

        public async Task<FeaturedProjects> GetFeaturedProjectsByNameAsync(string name)
        {
            try
            {
                var output = await _context.FeaturedProjects
                .FirstOrDefaultAsync(p => p.ProjectName.Equals(name, StringComparison.OrdinalIgnoreCase));

                if (output == null)
                {
                    throw new Exception("Projeto não encontrado");
                }
                return output;
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possível obter o projeto: {ex.Message}");
            }
        }

        public async Task AddFeaturedProjectsAsync(FeaturedProjects project)
        {
            _context.FeaturedProjects.Add(project);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFeaturedProjectsAsync(int id)
        {
            var project = await _context.FeaturedProjects.FindAsync(id);
            if (project != null)
            {
                _context.FeaturedProjects.Remove(project);
                await _context.SaveChangesAsync();
            }
        }

        public async Task GetFeaturedProjectsByIdAsync(int id)
        {
            await _context.FeaturedProjects.FindAsync(id);
        }
    }
}
