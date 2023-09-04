using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Repository
{

    public class EnfantRepository : IEnfantRepository
    {
        private readonly DataContext _context;

        public EnfantRepository(DataContext context)
        {
            _context = context;
        }

        public Enfant GetEnfant(int id)
        {
            return _context.Enfants.Where(e => e.Id == id).FirstOrDefault();
        }

        public IEnumerable<Enfant> GetEnfants()
        {
            return _context.Enfants.OrderByDescending(e => e.Id).AsEnumerable();
        }

        public bool CreateEnfant(Enfant enfant)
        {
            _context.Add(enfant);
            return Save();
        }

        public ICollection<Parrain> GetParrainsByEnfant(int EnfantId)
        {
            var parrains =
                _context.Enfants.Where(e => e.Id == EnfantId)
                .SelectMany(e => e.Parrainages.Select(p => p.Parrain))
                .ToList();

            return parrains;
        }

        public bool UpdateEnfant(Enfant enfant)
        {
            _context.Update(enfant);
            return Save();
        }

        public bool DeleteEnfant(Enfant enfant)
        {
            _context.Remove(enfant);
            return Save();
        }

        public bool EnfantExists(int id)
        {
            return _context.Enfants.Any(e => e.Id == id);
        }

        public bool Save()
        {
                var saved = _context.SaveChanges();
            return saved > 0;
        }

        public ICollection<Enfant> GetEnfantsWithNoFamille()
        {
            var enfants = _context.Enfants.OrderByDescending(e => e.Id).Where(e => e.FamilleId == null).ToList();
            return enfants;
        }
    }
}

