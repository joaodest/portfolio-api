using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace portfolio_api.Models.GithubModels
{
    public class GithubUser
    {
        private string _email = string.Empty;

        [Key]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("login")]
        public string Login { get; set; } = string.Empty;

        [JsonPropertyName("avatar_url")]
        public string AvatarURL { get; set; } = string.Empty;

        [JsonPropertyName("html_url")]
        public string ProfileURL { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "O campo 'Email' deve ser um endereço de e-mail válido.")]
        [JsonPropertyName("email")]
        public string Email
        {
            get => _email;
            set => _email = value ?? string.Empty;
        }
    }
}
