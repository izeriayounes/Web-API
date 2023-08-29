using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface IFamilleRepository
    {
        ICollection<Famille> GetFamilles();
        ICollection<Enfant> GetEnfantsByFamille(int familleId);
        Famille GetFamille(int id);
        public Famille GetFamilleByCode(string code);
        bool CreateFamille(int[] enfantIds, Famille famille);
        bool UpdateFamille(int[] enfantIds, Famille famille);
        bool DeleteFamille(Famille famille);
        bool FamilleExists(int id);
        bool Save();
    }

}

