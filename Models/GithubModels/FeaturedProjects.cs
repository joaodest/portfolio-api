using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace portfolio_api.Models.GithubModels
{
    public class FeaturedProjects
    {
        private string _defaultDescription = string.Empty;
        [Key]
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string ProjectName { get; set; } = string.Empty;
        [JsonPropertyName("description")]
        public string Description { 
            get => _defaultDescription; 
            set => _defaultDescription = value ?? _defaultDescription;
        }
        [JsonPropertyName("html_url")]
        public string Url { get; set; } = string.Empty;

        [JsonPropertyName("private")]
        public bool IsPrivate { get; set; }

    }
}
