using WebApi.Data;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Repository
{
    public class ParrainRepository : IParrainRepository
    {
        private readonly DataContext _context;

        public ParrainRepository(DataContext context)
        {
            _context = context;
        }


        public Parrain GetParrain(int id)
        {
            return _context.Parrains.Where(p => p.Id == id).FirstOrDefault();
        }

        public ICollection<Parrain> GetParrains()
        {
            return _context.Parrains.ToList();
        }
        public ICollection<Enfant> GetEnfantsByParrain(int ParrainId)
        {
            var enfants =
                _context.Parrains.Where(p => p.Id == ParrainId)
                .SelectMany(p => p.Parrainages.Select(ep => ep.Enfant))
                .ToList();

            return enfants;
        }
        public bool CreateParrain(Parrain parrain)
        {
            _context.Add(parrain);   
            return Save();
        }

        public bool DeleteParrain(Parrain parrain)
        {
            _context.Remove(parrain);
            return Save();
        }
        public bool UpdateParrain(Parrain parrain)
        {
            _context.Update(parrain);
            return Save();
        }

        public bool ParrainExists(int id)
        {
            return _context.Parrains.Any(p => p.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }

    }
}

