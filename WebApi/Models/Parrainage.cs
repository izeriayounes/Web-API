
namespace WebApi.Models;
public class Parrainage
{        
    public int EnfantId { get; set; }
    public int ParrainId { get; set; }
    public Enfant Enfant { get; set; }
    public Parrain Parrain { get; set; }
    public DateTime?  DateDebutKafala { get; set; }
    public int? MontantKafala { get; set; }
    public bool IsActive { get; set; }
    public string? Commentaire { get; set; }
}

