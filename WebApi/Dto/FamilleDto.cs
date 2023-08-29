
namespace WebApi.Dto
{
    public class FamilleDto
    {        
        public int Id { get; set; }
        public string CodeFamille { get; set; }
        public string NomFamille { get; set; }
        //pere
        public string? NomPere { get; set; }
        //mere
        public string? NomMere { get; set; }
        public string? TravailMere { get; set; }
        public string? TelMere { get; set; }
        //autres
        public string? LieuResidence { get; set; }
        public int? NombreGarcons { get; set; }
        public int? NombreFilles { get; set; }
        public DateTime? DateInscription { get; set; }
        public DateTime? DateDebutKafala { get; set; }

        public string? TypeHabitat { get; set; }//proprietaire/locataire

    }

}
