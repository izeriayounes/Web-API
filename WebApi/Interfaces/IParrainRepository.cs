using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface IParrainRepository
    {
        ICollection<Parrain> GetParrains();
        ICollection<Enfant> GetEnfantsByParrain(int parrainId);
        Parrain GetParrain(int id);
        bool CreateParrain(Parrain parrain);
        bool UpdateParrain(Parrain parrain);
        bool DeleteParrain(Parrain parrain);
        bool ParrainExists(int id);
        bool Save();
    }
}

