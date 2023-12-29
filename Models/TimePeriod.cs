using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class TimePeriod
{
    [Key]
    public int TimePeriodId { get; set; }

    [ForeignKey("Experiencia")]
    public int ExperienciaId { get; set; }

    public int Month { get; set; }
    public int Year { get; set; }
}
