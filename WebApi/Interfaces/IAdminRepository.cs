using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface IAdminRepository
    {
        Admin GetAdmin();
        bool Create(Admin admin);
        bool Update(Admin admin);

    }
}