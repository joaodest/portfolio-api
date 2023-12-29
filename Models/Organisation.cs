using System.ComponentModel.DataAnnotations;

namespace portfolio_api.Models
{
    public class Organisation
    {
        [Key]
        public int OrganisationId { get; set; }
        public string Name { get; set; } = string.Empty;

    }
}
