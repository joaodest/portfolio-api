using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace portfolio_api.Models.LinkedinModels
{
    public class LinkedInUser
    {
        //LIX API
        [Key]
        public int UserId { get; set; }

        public string Username { get; set; } = string.Empty;

        [JsonPropertyName("description")]
        public string Headline { get; set; } = string.Empty;

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("aboutSummaryText")]
        public string Summary { get; set; }

        [JsonPropertyName("link")]
        public string Link { get; set; }


        [JsonPropertyName("experience")]
        [ForeignKey("Experiencia")]
        public ICollection<Experiencia> Experiencias { get; set; }


    }
}