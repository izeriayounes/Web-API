
using System.Text.Json.Serialization;

namespace WebApi.Dto
{
    public class EnfantDto
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string? Sexe { get; set; }
        public DateTime? DateNaissance { get; set; }
        public string? LieuNaissance { get; set; }

        public string? NiveauScolaire { get; set; }
        public DateTime? DateInscription { get; set; }
        public DateTime? DateDebutKafala { get; set; }
        public string? Remarque { get; set; }
        public byte[]? ProfilePicture { get; set; }
    }

}

