using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using portfolio_api.Models.GithubModels;
using portfolio_api.Services;
using System.Net.Http.Headers;
using System.Text.Json;

namespace portfolio_api.Controllers
{

    [ApiController]
    public class GithubUserController : ControllerBase
    {
        private readonly HttpClient _http;
        private IGithubUserService _githubUserService;
        private IFeaturedProjectsService _featuredProjectsService;

        public GithubUserController(
            HttpClient http,
            IGithubUserService githubUserService,
            IFeaturedProjectsService featuredProjectsService)
        {
            _http = http;
            _githubUserService = githubUserService;
            _featuredProjectsService = featuredProjectsService;
        }

        [HttpGet("api/github/user")]
        public async Task<IActionResult> GetGithubUser(string accessToken)
        {
            var githubUser = await ExecuteGetAsync<GithubUser>(accessToken, "https://api.github.com/user");
            await _githubUserService.CreateGithubUserAsync(githubUser);
            return Ok(githubUser);
        }

        [HttpGet("api/github/user/repos")]
        public async Task<IActionResult> GetGithubUserRepos(string accessToken, string githubUser)
        {
            var reposUrl = $"https://api.github.com/users/{githubUser}/repos";
            var githubUserRepos = await ExecuteGetAsync<List<FeaturedProjects>>(accessToken, reposUrl);
            foreach (var repo in githubUserRepos)
            {
                await _featuredProjectsService.AddFeaturedProjectAsync(repo);
            }
            return Ok(githubUserRepos);
        }

        private async Task<T> ExecuteGetAsync<T>(string accessToken, string url)
        {
            _http.DefaultRequestHeaders.Accept.Clear();
            _http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            _http.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("AppName", "1.0"));
            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await _http.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Status code error: {response.StatusCode}");
            }

            var content = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            try
            {
                var output = JsonSerializer.Deserialize<T>(content, options);
                if (output == null)
                    throw new NullReferenceException(nameof(output));

                return output;
            }
            catch (JsonException ex)
            {
                // Aqui você pode logar detalhes do erro para ajudar na depuração
                throw new InvalidOperationException("Erro na deserialização do JSON.", ex);
            }
        }
    }
}
