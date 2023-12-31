using portfolio_api.Data;
using portfolio_api.Models.LinkedinModels;

namespace portfolio_api.Services
{
    public class LinkedInUserService : ILinkedInUserService
    {
        private readonly ILinkedInUserRepository _repository;

        public LinkedInUserService(ILinkedInUserRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateLinkedInUserAsync(LinkedInUser linkedInUser)
        {
            try
            {
                await _repository.CreateLinkedInUserAsync(linkedInUser);
                await  _repository.SaveChangesAsync();  
            }
            catch (HttpRequestException ex)
            {
                Console.Error.WriteLine($"Erro na chamada da API: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Erro na persistência dos dados: {ex.Message}");
            }
        }

    }
}
