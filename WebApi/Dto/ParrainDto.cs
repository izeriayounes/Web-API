
namespace WebApi.Dto
{
    public class ParrainDto
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string CIN { get; set; }
        public string Fonction { get; set; }
        public string Adresse { get; set; }
        public string Email { get; set; }
        public string GSM { get; set; }
        public DateTime DebutKafala { get; set; }
        public DateTime DatePremiereCotisation { get; set; }
        public int CotisationMensuelle { get; set; }
    }
}
