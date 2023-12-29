using portfolio_api.Models;

namespace portfolio_api.Data
{
    public interface ILinkedInUserRepository
    {
        LinkedInUser GetLinkedInUserById(int id);
        Task CreateLinkedInUserAsync(LinkedInUser linkedInUser);

        Task SaveChangesAsync();
    }
}
