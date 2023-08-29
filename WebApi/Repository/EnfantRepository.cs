using Microsoft.EntityFrameworkCore.Query.Internal;
using WebApi.Data;
using WebApi.Dto;
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

        public ICollection<Enfant> GetEnfants()
        {
            return _context.Enfants.ToList();
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

    }
}

