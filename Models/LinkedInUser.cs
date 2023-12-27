using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace portfolio_api.Models
{
    public class LinkedInUser
    {
        //LIX API

        [JsonPropertyName("description")]
        public string Headline { get; set; } = string.Empty;

        [JsonPropertyName("name")]
        public string FistName { get; set; } = string.Empty;

        [JsonPropertyName("aboutSummaryText")]
        public string Summary { get; set; }

        [JsonPropertyName("link")]
        public string Link { get; set; }

        [JsonPropertyName("experience")]
        public List<Experiencia> Experiences { get; set; }


    }
}
