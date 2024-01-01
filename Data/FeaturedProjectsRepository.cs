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
            return await _context.FeaturedProjects
                .FirstOrDefaultAsync(p => p.ProjectName.Equals(name, StringComparison.OrdinalIgnoreCase));
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
