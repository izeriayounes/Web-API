using WebApi.Data;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Repository
{
    public class ParrainageRepository : IParrainageRepository
    {
        private readonly DataContext _context;

        public ParrainageRepository(DataContext context)
        {
            _context = context;
        }
        public Parrainage GetParrainage(int EnfantId, int ParrainId)
        {
            return _context.Parrainages.Where(p => p.EnfantId == EnfantId 
                                                && p.ParrainId == ParrainId).FirstOrDefault();
        }
        public ICollection<Parrainage> GetParrainages()
        {
            return _context.Parrainages.ToList();
        }

        public bool CreateParrainage(Parrainage parrainage)
        {
            _context.Add(parrainage);
            return Save();
        }

        public bool UpdateParrainage(Parrainage parrainage)
        {
            _context.Update(parrainage);
            return Save();
        }

        public bool ParrainageExists(int EnfantId, int ParrainId)
        {
            return _context.Parrainages.Any(p => p.EnfantId == EnfantId && p.ParrainId == ParrainId);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }
    }
}
