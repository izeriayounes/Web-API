    using System.ComponentModel.DataAnnotations;

    namespace WebApi.Models;
    public class Parrain
    {
        public int Id { get; set; }

        [Display(Name = "اسم الكفيل")]
        public string Nom { get; set; }

        [Display(Name = "نسب الكفيل")]
        public string Prenom { get; set; }

        [Display(Name = "رقم ب ت و")]
        public string CIN { get; set; }

        [Display(Name = "المهنة")]
        public string? Fonction { get; set; }

        [Display(Name = "العنوان")]
        public string? Adresse { get; set; }

        [Display(Name = "البريد الإلكتروني")]
        public string? Email { get; set; }


        [Display(Name = "رقم الهاتف (المحمول)")]
        public string? GSM { get; set; }

        [Display(Name = "تاريخ بداية الكفالة")]
        [DataType(DataType.Date)]
        public DateTime? DateDebutKafala { get; set; }

        [Display(Name = "تاريخ أول مساهمة")]
        [DataType(DataType.Date)]
        public DateTime? DatePremiereCotisation { get; set; }

        [Display(Name = "قيمة المساهمة الشهرية")]
        public int? CotisationMensuelle { get; set; }

        public ICollection<Enfant> Enfants { get; set; }
        public ICollection<Parrainage> Parrainages { get; set; }
    }
