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

        private const string LinkedinUserInfo = "https://api.linkedin.com/v2/userinfo/";
        private readonly HttpClient _http;


        public LinkedInUserController(HttpClient http)
        {
            _http = http;
        }

        [HttpGet("user")]
        public async Task<LinkedInUser> GetLinkedInUserAsync(string accessToken)
        {
            return await ExecuteGetAsync(LinkedinUserInfo, accessToken);
        }

        [HttpGet]
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
        }

        private async Task<LinkedInUser> ExecuteGetAsync(string url, string accessToken)
        {

            _http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _http.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");

            var response = await _http.GetAsync(url);

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

