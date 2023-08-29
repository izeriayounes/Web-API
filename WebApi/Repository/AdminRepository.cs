using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly DataContext _context;

        public AdminRepository(DataContext context)
        {
            _context = context;
        }

        public Admin GetAdmin()
        {
            return _context.Admin.FirstOrDefault();
        }

        public bool Update(Admin admin)
        {
            _context.Update(admin);
            return Save();
        }
        public bool Create(Admin admin)
        {
            var Hashedadmin = new Admin
            {
                UserName = admin.UserName,
                Password = BCrypt.Net.BCrypt.HashPassword(admin.Password)
            };

            _context.Add(Hashedadmin);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }

    }

}
