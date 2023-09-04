using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface IEnfantRepository
    {
        IEnumerable<Enfant> GetEnfants();
        Enfant GetEnfant(int id);
        ICollection<Parrain> GetParrainsByEnfant(int EnfantId);
        ICollection<Enfant> GetEnfantsWithNoFamille();
        bool CreateEnfant(Enfant enfant);
        bool UpdateEnfant(Enfant enfant);
        bool DeleteEnfant(Enfant enfant);
        bool EnfantExists(int id);
        bool Save();
    }

}

