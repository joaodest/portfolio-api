namespace portfolio_api.Models
{
    public class TimePeriod
    {
        public StartedPeriod Started { get; set; }
        public EndedOn Ended { get; set; }
    }

    public class EndedOn
    {
        public string Month { get; set; } = string.Empty;
        public string Year { get; set; } = string.Empty;
    }

    public class StartedPeriod
    {
        public string Month { get; set; } = string.Empty;
        public string Year { get; set; } = string.Empty;
    }
}
