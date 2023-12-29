using portfolio_api.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class Experiencia
{
    [Key]
    public int ExperienciaId { get; set; }

    [ForeignKey("LinkedInUser")]
    public int UserId { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;

    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;

    [JsonPropertyName("dateStarted")]
    public string DateStarted { get; set; }

    [JsonPropertyName("dateEnded")]
    public string? DateEnded { get; set; }

    [ForeignKey("Organisation")]
    public int OrganisationId { get; set; }

    [JsonPropertyName("organisation")]
    public Organisation Organisation { get; set; }

    [ForeignKey("TimePeriod")]
    public int TimePeriodId { get; set; }
    public TimePeriod TimePeriod { get; set; }
}
