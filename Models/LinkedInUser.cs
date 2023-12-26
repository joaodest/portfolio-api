using System.Text.Json.Serialization;

namespace portfolio_api.Models
{
    public class LinkedInUser
    {
        [JsonPropertyName("id")]
        public int ID { get; set; }

        [JsonPropertyName("given_name")]
        public string FistName { get; set; } = string.Empty;

        [JsonPropertyName("picture")]
        public string Pfp { get; set; } = string.Empty;

    }
}
