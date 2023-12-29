using portfolio_api.Models;

namespace portfolio_api.Services
{
    public interface ILinkedInUserService
    {
        public Task CreateLinkedInUserAsync(LinkedInUser linkedInUser);

    }
}
