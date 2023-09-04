using System.ComponentModel.DataAnnotations;

namespace WebApi.Models;
public class Famille 
{        
    public int Id { get; set; }

    [Display(Name = "رقم العائلة")]
    public string CodeFamille { get; set; }

    [Display(Name = "اسم العائلة")]
    public string NomFamille { get; set; }

    //pere
    [Display(Name = "اسم الأب")]
    public string? NomPere { get; set; }
       
    //mere
    [Display(Name = "اسم الأم")]
    public string? NomMere { get; set; }

    [Display(Name = "عمل الأم")]
    public string? TravailMere { get; set; }

    [Display(Name = "رقم هاتف الأم")]
    public string? TelMere { get; set; }

    //autres
    [Display(Name = "مكان الإقامة")]
    public string? LieuResidence { get; set; }

    [Display(Name = "عدد الأطفال من الذكور")]
    public int? NombreGarcons { get; set; }

    [Display(Name = "عدد الأطفال من الإناث")]
    public int? NombreFilles { get; set; }

    [Display(Name = "تاريخ التسجيل")]
    [DataType(DataType.Date)]
    public DateTime? DateInscription { get; set; }

    [Display(Name = "تاريخ بداية الكفالة")]
    [DataType(DataType.Date)]
    public DateTime? DateDebutKafala { get; set; }

    [Display(Name = "نوع السكن")]
    public string? TypeHabitat { get; set; }
    
    public ICollection<Enfant> Enfants { get; set; }

}
