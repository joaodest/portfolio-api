using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using portfolio_api.Models.GithubModels;
using portfolio_api.Models.LinkedinModels;

namespace portfolio_api.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration)
            : base(options) { }

        public DbSet<LinkedInUser> LinkedInUsers { get; set; }
        public DbSet<Experiencia> Experiencias { get; set; }
        public DbSet<Organisation> Organisations { get; set; }
        public DbSet<TimePeriod> TimePeriods { get; set; }

        public DbSet<GithubUser> GithubUsers { get; set; }

    }
}