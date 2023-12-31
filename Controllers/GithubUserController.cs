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
        private IGithubUserService _service;

        public GithubUserController(HttpClient http, IGithubUserService service)
        {
            _http = http;
            _service = service;
            _http.BaseAddress = new Uri("https://api.github.com/user");

        }

        [HttpGet("api/github/github-user")]
        public async Task<IActionResult> GetGithubUser(string accessToken)
        {
            var githubUser = await ExecuteGetAsync(accessToken);
            await _service.CreateGithubUserAsync(githubUser);
            return Ok(githubUser);
        }

        private async Task<GithubUser> ExecuteGetAsync(string accessToken)
        {
            _http.DefaultRequestHeaders.Accept.Clear();
            _http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            _http.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("AppName", "1.0"));
            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await _http.GetAsync(_http.BaseAddress);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(
                                       $"Status code error: {response.StatusCode}"
                                                          );
            }

            var content = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var githubUser = JsonSerializer.Deserialize<GithubUser>(content, options);

            if (githubUser == null)
                throw new NullReferenceException(nameof(githubUser));

            return githubUser;
        }
    }
}