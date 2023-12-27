namespace portfolio_api.Models
{
    public class Experiencia
    {
        public string Description { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;

        public string DateStarted { get; set; } = string.Empty;
        public string DateEnded { get; set; } = string.Empty;

        public Organisation Org { get; set; }

        public TimePeriod Period { get; set; }
    }
}