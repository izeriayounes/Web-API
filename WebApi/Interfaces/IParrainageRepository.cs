using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface IParrainageRepository
    {
        ICollection<Parrainage> GetParrainages();
        Parrainage GetParrainage(int EnfantId, int ParrainId);
        bool CreateParrainage(Parrainage parrainage);
        bool UpdateParrainage(Parrainage parrainage);
        bool ParrainageExists(int EnfantId, int ParrainId);
        bool Save();
    }

}

