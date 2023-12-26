using portfolio_api.Models;

namespace portfolio_api.Controllers
{
    public interface ILinkedInUserManager
    {
        Task<LinkedInUser> GetLinkedInUserAsync(string accessToken);
    }
}