using portfolio_api.Models.LinkedinModels;

namespace portfolio_api.Services
{
    public interface ILinkedInUserService
    {
        public Task CreateLinkedInUserAsync(LinkedInUser linkedInUser);

    }
}
