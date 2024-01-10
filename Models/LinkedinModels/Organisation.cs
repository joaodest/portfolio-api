using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace portfolio_api.Models.LinkedinModels
{
    public class Organisation
    {
        [Key]
        public int OrganisationId { get; set; }

        [ForeignKey("Experiencia")]
        public int ExperienciaId { get; set; }

        public string Name { get; set; } = string.Empty;



    }
}
