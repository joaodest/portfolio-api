using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Net.WebRequestMethods;
using System.Net.Http.Headers;
using System.Text.Json;
using portfolio_api.Services;
using portfolio_api.Models.LinkedinModels;

namespace portfolio_api.Controllers
{
    [Route("api/linkedin")]
    [ApiController]
    public class LinkedInUserController : ControllerBase
    {

        private const string LinkedinUserInfo = "https://api.lix-it.com/v1/person";
        private readonly ILinkedInUserService _services;
        private readonly HttpClient _http;


        public LinkedInUserController(HttpClient http, ILinkedInUserService services)
        {
            _services = services;
            _http = http;
        }

        [HttpGet("/user")]
        public async Task<IActionResult> GetLinkedInUserAsync(string accessToken, string profileLink)
        {
            var linkedinUser = await ExecuteGetAsync(LinkedinUserInfo, accessToken, profileLink);
            _services.CreateLinkedInUserAsync(linkedinUser);

            return Ok(linkedinUser);
        }

        private async Task<LinkedInUser> ExecuteGetAsync(string url, string accessToken, string profileLink)
        {

            _http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _http.DefaultRequestHeaders.Add("Authorization", $"{accessToken}");

            var encodedProfileLink = Uri.EscapeDataString(profileLink);

            var requestUrl = $"{url}?profile_link=https://linkedin.com/in/{encodedProfileLink}";

            var response = await _http.GetAsync(requestUrl);

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

            var results = JsonSerializer.Deserialize<LinkedInUser>(content, options);

            if (results == null)
            {
                throw new HttpRequestException(
                   $"Deserialize error: {content}"
                   );
            }

            return results;
        }
    }


}

