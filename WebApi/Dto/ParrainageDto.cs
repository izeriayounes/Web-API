
namespace WebApi.Dto
{
    public class ParrainageDto
    {        
        public int EnfantId { get; set; }
        public int ParrainId { get; set; }
        public DateTime? DateDebutKafala { get; set; }
        public int? MontantKafala { get; set; }
        public bool IsActive { get; set; }
        public string? Commentaire { get; set; }
    }

}
