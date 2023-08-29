using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApi.Models;
public class Enfant
{
    [Display(Name = "رقم اليتيم")]
    public int Id { get; set; }

    [Display(Name = "اسم اليتيم")]
    public string Nom { get; set; }

    [Display(Name = "نسب اليتيم")]
    public string Prenom { get; set; }

    [Display(Name = "جنس اليتيم")]
    public string? Sexe { get; set; }

    [Display(Name = "تاريخ ميلاد اليتيم")]
    [DataType(DataType.Date)]
    public DateTime? DateNaissance { get; set; }

    [Display(Name = "مكان ميلاد اليتيم")]
    public string? LieuNaissance { get; set; }

    [Display(Name = "المستوى الدراسي")]
    public string? NiveauScolaire { get; set; }

    [Display(Name = "تاريخ التسجيل")]
    [DataType(DataType.Date)]
    public DateTime? DateInscription { get; set; }

    [Display(Name = "تاريخ بداية الكفالة")]
    [DataType(DataType.Date)]
    public DateTime? DateDebutKafala { get; set; }

    [Display(Name = "ملاحظات")]
    public string? Remarque { get; set; }

    [Display(Name = "صورة اليتيم")]
    public byte[]? ProfilePicture { get; set; }
		    
    public Famille? Famille { get; set; }
    public ICollection<Parrain> Parrains { get; set; }
    public ICollection<Parrainage> Parrainages { get; set; }
}

