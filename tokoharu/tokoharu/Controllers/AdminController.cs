using tokoharu.Models;
using TokoHaru.Repositories;

namespace tokoharu.Controllers
{
    public class AdminController
    {
        private readonly AdminRepository _adminRepository;

        public AdminController(DBConnection dbConnection)
        {
            _adminRepository = new AdminRepository(dbConnection);
        }

        public string GetAdminName()
        {
            return _adminRepository.GetAdminName();
        }
    }
}