using portfolio_api.Models.LinkedinModels;

namespace portfolio_api.Data
{
    public class LinkedInUserRepository : ILinkedInUserRepository
    {

        private readonly AppDbContext _context;

        public LinkedInUserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateLinkedInUserAsync(LinkedInUser linkedInUser)
        {
            if (linkedInUser.Equals(null))
                throw new ArgumentNullException(nameof(linkedInUser));

             await _context.LinkedInUsers.AddAsync(linkedInUser);
        }

        public LinkedInUser GetLinkedInUserById(int id) =>
            _context.LinkedInUsers.FirstOrDefault(p => p.UserId == id);

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }


    }
}
