using WebApi.Data;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Repository
{
    public class FamilleRepository : IFamilleRepository
    {
        private readonly DataContext _context;

        public FamilleRepository(DataContext context)
        {
            _context = context;
        }

        public Famille GetFamille(int id)
        {
            return _context.Familles.Where(f => f.Id == id).FirstOrDefault();
        }

        public ICollection<Famille> GetFamilles()
        {
            return _context.Familles.OrderByDescending(f => f.Id).ToList();
        }

        public ICollection<Enfant> GetEnfantsByFamille(int familleId)
        {
            var enfants =
                _context.Familles.Where(f => f.Id == familleId)
                .SelectMany(f => f.Enfants)
                .ToList();

            return enfants;
        }

        public bool CreateFamille(int[] enfantIds, Famille famille)
        {
            var enfants = _context.Enfants.Where(e => enfantIds.Contains(e.Id)).ToList();

            famille.Enfants = enfants;

            _context.Add(famille);
            return Save();
        }


        public bool UpdateFamille(int[] enfantIds, Famille famille)
        {
            var enfants = _context.Enfants.Where(e => enfantIds.Contains(e.Id)).ToList();

            var existingEnfants = GetEnfantsByFamille(famille.Id);

            var concatenatedEnfants = existingEnfants.Concat(enfants).ToList();

            famille.Enfants = concatenatedEnfants;

            _context.Update(famille);
            return Save();
        }

        public bool DeleteFamille(Famille famille)
        {
            var enfants =
                _context.Familles.Where(f => f.Id == famille.Id)
                .SelectMany(f => f.Enfants)
                .ToList();

            foreach (var enfant in enfants)
                enfant.Famille = null;

            _context.Remove(famille);
            return Save();
        }

        public bool FamilleExists(int id)
        {
            return _context.Familles.Any(f => f.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }

        public bool FamilleExists(string code)
        {
            return _context.Familles.Any(f => f.CodeFamille == code);
        }
    }

}

