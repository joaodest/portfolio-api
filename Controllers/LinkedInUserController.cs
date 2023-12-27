using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using portfolio_api.Models;
using static System.Net.WebRequestMethods;
using System.Net.Http.Headers;
using System.Text.Json;

namespace portfolio_api.Controllers
{
    [Route("api/linkedin")]
    [ApiController]
    public class LinkedInUserController : ControllerBase
    {

        private const string LinkedinUserInfo = "https://api.lix-it.com/v1/person";
        private readonly HttpClient _http;


        public LinkedInUserController(HttpClient http)
        {
            _http = http;
        }

        [HttpGet("user")]
        public async Task<LinkedInUser> GetLinkedInUserAsync(string accessToken, string profileLink)
        {
            return await ExecuteGetAsync(LinkedinUserInfo, accessToken, profileLink);
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

    /*[HttpGet("user/firstname")]
        public async Task<string> GetUserFirstName(string accessToken)
        {
            try
            {
                var user = await GetLinkedInUserAsync(accessToken);
                return user.FistName.ToString().Split(" ")[0];
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);                
            }
        }*/
}

